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
    using System.Collections.ObjectModel;
    using System.Collections;
    
    namespace WpfApplication2
    {
        /// <summary>
        /// Interaction logic for UserControl1.xaml
        /// </summary>
        public partial class UserControl1 : UserControl
        {
            public IEnumerable UCApps
            {
                get { return (IEnumerable)GetValue(UCAppsProperty); }
                set { SetValue(UCAppsProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for Apps.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty UCAppsProperty =
                DependencyProperty.Register("UCApps", typeof(IEnumerable), typeof(UserControl1), new UIPropertyMetadata(null));
    
            public UserControl1()
            {
                InitializeComponent();            
            }
        }
    }
