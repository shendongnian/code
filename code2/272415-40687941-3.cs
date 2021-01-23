    namespace Behaviors
    {
        public class DynamicConditionBehavior : Behavior<GridControl>
        {
            GridControl Grid => AssociatedObject;
    
            protected override void OnAttached()
            {
                base.OnAttached();
                Grid.ItemsSourceChanged += OnItemsSourceChanged;
            }
    
            protected override void OnDetaching()
            {
                Grid.ItemsSourceChanged -= OnItemsSourceChanged;
                base.OnDetaching();
            }
    
            public ColorScaleFormat ColorScaleFormat { get; set;}
            public float MinValue { get; set; }
            public float MaxValue { get; set; }
            
            private void OnItemsSourceChanged(object sender, EventArgs e)
            {
                var view = Grid.View as TableView;
    
                if (view == null) return;
            
                view.FormatConditions.Clear();
    
                foreach (var col in Grid.Columns)
                {
                    view.FormatConditions.Add(new ColorScaleFormatCondition
                    {
                        MinValue = MinValue,
                        MaxValue = MaxValue,
                        FieldName = col.FieldName,
                        Format = ColorScaleFormat,
                    });
                }
    
            }
        }
    }
