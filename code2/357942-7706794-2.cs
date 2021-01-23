    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Collections.ObjectModel;
    using WpfBindingSample.Models;
    
    namespace WpfBindingSample
    {
        public class MainWindowViewModel : DependencyObject
        {
            public MainWindowViewModel()
            {
                People = new System.Collections.ObjectModel.ObservableCollection<Person>();
            }
    
            public Person SelectedPerson
            {
                get { return (Person)GetValue(SelectedPersonProperty); }
                set { SetValue(SelectedPersonProperty, value); }
            }
    
            // Using a DependencyProperty as the backing store for SelectedPerson.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SelectedPersonProperty =
                DependencyProperty.Register("SelectedPerson", typeof(Person), typeof(MainWindowViewModel), new UIPropertyMetadata(null));
    
            public ObservableCollection<Person> People { get; set; }
        }
    }
