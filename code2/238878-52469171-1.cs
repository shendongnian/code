    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    namespace MultiRegionListBox
    {
        internal class SharedLayoutCoordinator : DependencyObject
        {
            private List<SharedLayoutRegion> Regions = new List<SharedLayoutRegion>();
            public SharedLayoutRegion this[int index]
            {
                get
                {
                    var slr = new SharedLayoutRegion(this, index);
                    for (int i = 0; i < Regions.Count; i++)
                    {
                        if (Regions[i].Index > index)
                        {
                            Regions.Insert(i, slr);
                            return slr;
                        }
                    }
                    Regions.Add(slr);
                    return slr;
                }
            }
            public object ItemsSource
            {
                get { return (object)GetValue(ItemsSourceProperty); }
                set { SetValue(ItemsSourceProperty, value); }
            }
            public static readonly DependencyProperty ItemsSourceProperty =
                DependencyProperty.Register("ItemsSource", typeof(object), typeof(SharedLayoutCoordinator), new PropertyMetadata(null));
            public static SharedLayoutRegion GetRegion(DependencyObject obj)
            {
                return (SharedLayoutRegion)obj.GetValue(RegionProperty);
            }
            public static void SetRegion(DependencyObject obj, SharedLayoutRegion value)
            {
                obj.SetValue(RegionProperty, value);
            }
            public static readonly DependencyProperty RegionProperty =
                DependencyProperty.RegisterAttached("Region", typeof(SharedLayoutRegion),
                    typeof(SharedLayoutCoordinator), new PropertyMetadata(null, Region_Changed));
            private static void Region_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                var itemsControl = (ItemsControl)d;
                var newController = (SharedLayoutRegion)e.NewValue;
                if (newController == null)
                {
                    return;
                }
                itemsControl.SetBinding(ItemsControl.ItemsSourceProperty, new Binding(nameof(ItemsSource)) { Source = newController.Coordinator });
            }
            public static SharedLayoutRegion GetParentSharedLayoutController(DependencyObject obj)
            {
                while (obj != null)
                {
                    if (obj is ItemsControl ic)
                    {
                        var slc = GetRegion(ic);
                        if (slc != null)
                        {
                            return slc;
                        }
                    }
                    obj = VisualTreeHelper.GetParent(obj);
                }
                return null;
            }
            public IEnumerable<SharedLayoutRegion> GetPreceedingRegions(SharedLayoutRegion region)
            {
                return Regions.Where(r => r.Index < region.Index);
            }
            internal SharedLayoutRegion GetNextRegion(SharedLayoutRegion region)
            {
                var idx = Regions.IndexOf(region);
                if (idx + 1 < Regions.Count)
                {
                    return Regions[idx + 1];
                }
                return null;
            }
            internal SharedLayoutRegion GetPreviousRegion(SharedLayoutRegion region)
            {
                var idx = Regions.IndexOf(region);
                if (idx > 0)
                {
                    return Regions[idx - 1];
                }
                return null;
            }
        }
        internal class SharedLayoutRegion
        {
            private Action InvalidateMeasureCallback;
            public SharedLayoutRegion(SharedLayoutCoordinator coord, int index)
            {
                this.Coordinator = coord;
                this.Index = index;
            }
            public SharedLayoutCoordinator Coordinator { get; }
            public int Index { get; }
            public SharedLayoutStackPanel Panel { get; set; }
            public bool IsMeasureValid
                => !(Panel == null || !Panel.IsMeasureValid || Panel.IsMeasureMeaningless);
            internal bool CanMeasure(Action invalidateMeasure)
            {
                if (Coordinator.GetPreceedingRegions(this).All(pr => pr.IsMeasureValid))
                {
                    return true;
                }
                this.InvalidateMeasureCallback = invalidateMeasure;
                return false;
            }
            public int StartOfRegion => Coordinator.GetPreviousRegion(this)?.EndOfRegion ?? 0;
            public int CountInRegion { get; set; }
            public int EndOfRegion => CountInRegion + StartOfRegion;
            public bool HasNextRegion => Coordinator.GetNextRegion(this) != null;
            internal void OnMeasure()
            {
                var nextRegion = Coordinator.GetNextRegion(this);
                if (nextRegion != null && nextRegion.InvalidateMeasureCallback != null)
                {
                    nextRegion.InvalidateMeasureCallback();
                    nextRegion.InvalidateMeasureCallback = null;
                }
            }
        }
    }
