    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    namespace PersonTests
    {
    	public class PersonViewModel : INotifyPropertyChanged
    	{
    		private Person m_Person = null;
    
    		private readonly ObservableCollection<Person> m_AvailablePersons =
    			new ObservableCollection<Person>(new List<Person> {
    			   new Person("Mike", "Smith"),
    			   new Person("Jake", "Jackson"),                                                               
    			   new Person("Anne", "Aardvark"),                                                               
    		});
    
    		public ObservableCollection<Person> AvailablePersons
    		{
    			get { return m_AvailablePersons; }
    		}
    
    		public Person CurrentPerson
    		{
    			get { return m_Person; }
    			set
    			{
    			    if (m_Person != value)
    			    {
    			        m_Person = value;
    			        NotifyPropertyChanged("CurrentPerson");
    			    }
    			}
    
    			//set // This works
    			//{
    			//	if (m_AvailablePersons.Contains(value)) {
    			//	   m_Person = m_AvailablePersons.Where(p => p.Equals(value)).First();
    			//	}
    			//	else throw new ArgumentOutOfRangeException("value");
    			//	NotifyPropertyChanged("CurrentPerson");
    			//}
    		}
    
    		private void NotifyPropertyChanged(string name)
    		{
    			if (PropertyChanged != null)
    			{
    				PropertyChanged(this, new PropertyChangedEventArgs(name));
    			}
    		}
    
    		public event PropertyChangedEventHandler PropertyChanged;
    	}
    
    	public class Person
    	{
    		public string Firstname { get; set; }
    		public string Surname { get; set; }
    
    		public Person(string firstname, string surname)
    		{
    			this.Firstname = firstname;
    			this.Surname = surname;
    		}
    
    		public override string ToString()
    		{
    			return Firstname + "  " + Surname;
    		}
    
    		public override bool Equals(object obj)
    		{
    			if (obj is Person)
    			{
    				Person other = obj as Person;
    				if (other.Firstname == Firstname && other.Surname == Surname)
    				{
    					Debug.WriteLine(string.Format("{0} == {1}", other.ToString(), this.ToString()));
    					return true;
    				}
    				else
    				{
    					Debug.WriteLine(string.Format("{0} <> {1}", other.ToString(), this.ToString()));
    					return false;
    				}
    			}
    			return base.Equals(obj);
    		}
    	}
    }
