    using System.Collections.Generic;
    using System.Windows.Data;
    using System.Windows.Input;
    using ContextMenuNotFiring.Commands;
    using ContextMenuNotFiring.Models;
    
    namespace StackOverflow.ViewModels
    {
      public class MainViewModel : ViewModelBase
      {
        public MainViewModel()
        {
          AddPerson = new DelegateCommand<object>(OnAddPerson, CanAddPerson);
           
          CollectionContainer customers = new CollectionContainer();
          customers.Collection = Customer.GetSampleCustomerList();
           
          CollectionContainer persons = new CollectionContainer();
          persons.Collection = Person.GetSamplePersonList();
           
          _oc.Add(customers);
          _oc.Add(persons);
        }
        
        private CompositeCollection _oc = new CompositeCollection();
        public CompositeCollection ObjectCollection
        {
          get { return _oc; }
        }
        
        private object _so = null;
        public object SelectedObject
        {
          get { return _so; }
          set
          {
           _so = value;
          }
        }
         
        public ICommand AddPerson { get; set; }
        private void OnAddPerson(object obj)
        {
          CollectionContainer ccItems = _oc[1] as CollectionContainer;
          if ( ccItems != null )
          {
            ObservableCollection<Person> items = ccItems.Collection as ObservableCollection<Person>;
            if (items != null)
            {
              Person p = new Person("AAAA", "BBBB");
              items.Add(p);
            }
          }
        }
        
        private bool CanAddPerson(object obj)
        {
          return true;
        }
      }
    }
