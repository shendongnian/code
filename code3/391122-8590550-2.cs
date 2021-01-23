    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            public Dictionary<int, int> MyValues
            {
                get
                {
                    return Enumerable.Range(1, 3).ToDictionary(k => k, v => v);
                }
            }
        }
    
        public class Imperative : FrameworkElement
        {
            public void Add(int x, int y)
            {
                MessageBox.Show(string.Format("{0}_{1}", x, y));
            }
        }
    
    
        public class DeclarativeBehavior : DependencyObject
        {
            public static DependencyProperty MissingPropertyProperty =
                DependencyProperty.RegisterAttached("MissingProperty",
                typeof(Dictionary<int, int>),
                typeof(DeclarativeBehavior),
                new PropertyMetadata((o, e) => 
                { 
                    //
                    Imperative imperative = (Imperative)o;
                    Dictionary<int, int> values = (Dictionary<int, int>)e.NewValue;
    
    
                    if (imperative != null)
                    {
                        foreach (KeyValuePair<int, int> value in values)
                        {
                            imperative.Add(value.Key, value.Value);
                        }
                    }
                }));
    
            public static void SetMissingProperty(DependencyObject o, Dictionary<int, int> e)
            {
                o.SetValue(DeclarativeBehavior.MissingPropertyProperty, e);
            }
    
            public static Dictionary<int, int> GetMissingProperty(DependencyObject o)
            {
                return (Dictionary<int, int>)o.GetValue(DeclarativeBehavior.MissingPropertyProperty);
            }
        }
    }
