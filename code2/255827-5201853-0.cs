    using System;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Media;
    
    namespace Converters
    {
        public class AlternatingRowConverter : IValueConverter
        {
            public Brush NormalBrush { get; set; }
            public Brush AlternateBrush { get; set; }
            public int AlternateEvery { get; set; }
            public string Property { get; set; }
    
            public AlternatingRowConverter()
            {
                AlternateEvery = 1;
                Property = "Background";
            }
    
            public object Convert(
                object value, Type targetType, object parameter, CultureInfo culture)
            {
                var element = (FrameworkElement)value;
                element.Loaded += Element_Loaded;
    
                return NormalBrush;
            }
    
            public object ConvertBack(
                object value, Type targetType, object parameter, CultureInfo culture)
            {
                throw new NotImplementedException();
            }
    
            private void Element_Loaded(object sender, RoutedEventArgs e)
            {
                var element = (FrameworkElement)sender;
    
                DependencyObject obj = element;
                do
                {
                    obj = VisualTreeHelper.GetParent(obj);
                } while (!(obj is ItemsControl) && obj != null);
    
                var parent = (ItemsControl)obj;
                if (parent != null)
                {
                    DependencyObject container =
                        parent.ItemContainerGenerator.ContainerFromItem(
                        element.DataContext);
    
                    if (container != null)
                    {
                        int index = parent.ItemContainerGenerator.IndexFromContainer(
                            container);
    
                        if (index % (AlternateEvery * 2) >= AlternateEvery)
                            element.GetType().GetProperty(Property)
                                .SetValue(element, AlternateBrush, null);
                    }
                }
            }
        }
    }
