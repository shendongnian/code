    using System.Collections.Generic;
    using System.Windows;
    using TemplateSelector.Models;
    
    namespace TemplateSelector.Views
    {
      public partial class ScrollBarwindow : Window
      {
        public List<Person> Persons { get; private set; }
        
        public ScrollBarwindow()
        {
          this.Persons = new List<Person>()
            {
                new Person(){Working=true,Age=10},
                new Person(){Working=false,Age=20},
                new Person(){Working=true,Age=30},
                new Person(){Working=false,Age=40},
            };
         InitializeComponent();
        }
      }
    }
    
    
    namespace TemplateSelector.Models
    {
      public class Person
      {
        public bool Working { get; set; }
        public int Age { get; set; }
      }
    }
