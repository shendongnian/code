    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace DelegatesAndEvents
    {
        class Program
        {
            static void Main(string[] args)
            {
                Person p = new Person();
                //here you have an event of type EventHandler and want to subscribe with a delegate of type 
                //NameChangeEventHandlerDel. This can't work. Furthermore you have to create the delegate passing 
                //a method.
                //p.NameChangeEventHandler += new Person.NameChangeEventHandlerDel;
                // this could be better (even if I'm not sure about the necessity to use an event, 
                //but it probably depends on what you really are trying to do):
                p.NameChangeEventHandler += new EventHandler(p.NameChange);
                p.Name = "Paul";
            }
        }
        class Person
        {
            #region Events
            // why do you define the delegate NameChangeEventHandlerDel and then declare the event of type EventHandler?
            public delegate void NameChangeEventHandlerDel(object sender, EventArgs args);
            public event EventHandler NameChangeEventHandler;
         
            protected void NameChange(EventArgs arg)
            {
                Console.WriteLine("Name change...");
            }
            #endregion
            #region Properties
            private string name;
            public string Name
            {
                get { return name; }
                set 
                {
                    // here you should not call your method directly, but trigger the event (if this is what you want)
                    //i.e not: NameChange(null); but something like:
                    if (NameChangeEventHandler != null)
                        NameChangeEventHandler(this, null);
                    name = value;
                }
            }
            #endregion
            public Person(string name = "John")
            {
                this.name = name;
            }
        }
    }
