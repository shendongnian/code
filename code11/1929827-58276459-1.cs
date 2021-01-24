    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace TestLinkedList1
    {
        public class TestClass
        {
    
            public void DoStuff()
            {
                MyObject myobj1 = new MyObject();
                MyObject myobj2 = new MyObject();
    
                myobj1.property1 = "Foo";
                myobj2.property1 = "Bar";
    
                LinkedList<MyObject> genericLinkedListofMyObjects = new LinkedList<MyObject>();
    
                genericLinkedListofMyObjects.AddFirst(myobj1);
                genericLinkedListofMyObjects.AddFirst(myobj2);
    
                foreach (var item in genericLinkedListofMyObjects)
                {
                    string mystring = item.property1; //WORKS!
                }
    
            }
    
        }
    
        public class MyObject
        {
            public string property1 { get; set; }
        }
    
    }
