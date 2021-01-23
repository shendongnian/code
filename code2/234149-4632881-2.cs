    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                var test = new Wrapper();
                var test2 = test.GetValue<String>("Name");
                foreach (var val in test2)
                {
                    Console.WriteLine(val);
                }
            }
        }
    }
    
    	class Person
    	{
    		 public string Name;
    		 int Age;
    		 DateTime BirthDate;
    	}
    
        public class Wrapper
        {
            List<Person> PersonList = new List<Person> { new Person() { Name = "rob" }, new Person() { Name = "Test" } };
    
            public List<Object> GetValue(String column)
            {
                return GetValue<Object>(column);
            }
            public List<T> GetValue<T>(String column)
            {
                if (PersonList.Count > 0)
                {
                    var field = PersonList.FirstOrDefault().GetType().GetField(column);
                    if (field == null)
                        return null;
    
                    return PersonList.Select(person => (T) field.GetValue(person)).ToList();
                }
                return null;
            }
        }
