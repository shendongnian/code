    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media;
    
    namespace WpfApplication2
    {
        public static class FrameworkElementHelper
        {
            public static IEnumerable<Style> FindStylesOfType<TStyle>(this FrameworkElement frameworkElement)
            {
                IEnumerable<Style> styles = new List<Style>();
    
                var node = frameworkElement;
    
                while (node != null)
                {
                    styles = styles.Concat(node.Resources.Values.OfType<Style>().Where(i => i.TargetType == typeof(TStyle)));
                    node = VisualTreeHelper.GetParent(node) as FrameworkElement;
                }
    
                return styles;
            }
        }
    }
