    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    
    namespace WpfBindingSample.Models
    {
        public class Person : DependencyObject
        {
    
    
            public string FirstName
            {
                get { return (string)GetValue(FirstNameProperty); }
                set { SetValue(FirstNameProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for FirstName.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty FirstNameProperty =
                DependencyProperty.Register("FirstName", typeof(string), typeof(Person), new UIPropertyMetadata(""));
    
    
    
            public string LastName
            {
                get { return (string)GetValue(LastNameProperty); }
                set { SetValue(LastNameProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for LastName.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty LastNameProperty =
                DependencyProperty.Register("LastName", typeof(string), typeof(Person), new UIPropertyMetadata(""));
    
    
            
        }
    }
