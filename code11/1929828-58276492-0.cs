    using System;
    using System.Collections.Generic;
    
    namespace TestLinkedList
    {
        class Program
        {
            static void Main(string[] args)
            {
                var test = new TestLinkedList();
                test.Test1();
                Console.WriteLine();
                test.Test2();
                Console.WriteLine();
                test.Test3();
                Console.WriteLine();
                Console.WriteLine("Done!");
                Console.ReadKey();
            }
        }
    
        public class MyObject
        {
            public string property1 { get; set; }
            public string property2 { get; set; }
        }
    
        public class TestLinkedList
        {
            private LinkedList<MyObject> _genericLinkedListOfMyObjects; 
    
            public void Test1()
            {
                Console.WriteLine("Test1");
                _genericLinkedListOfMyObjects = new LinkedList<MyObject>();
                _genericLinkedListOfMyObjects.AddFirst(new MyObject{ property1="Prop1 Test1", property2="Prop2 Test1" });
                _genericLinkedListOfMyObjects.AddFirst(new MyObject{ property1="Prop1 Test2", property2="Prop2 Test2" });
    
                foreach (MyObject item in _genericLinkedListOfMyObjects)
                {
                    Console.WriteLine(item.property1);
                    Console.WriteLine(item.property2);
                }
            }
    
            public void Test2()
            {
                Console.WriteLine("Test2");
                _genericLinkedListOfMyObjects = new LinkedList<MyObject>();
                _genericLinkedListOfMyObjects.AddFirst(new MyObject{ property1="Prop1 Test1", property2="Prop2 Test1" });
                _genericLinkedListOfMyObjects.AddFirst(new MyObject{ property1="Prop1 Test2", property2="Prop2 Test2" });
    
                LinkedListNode<MyObject> current = _genericLinkedListOfMyObjects.First;
                while (current !=null)
                {
                    Console.WriteLine(current.Value.property1);
                    Console.WriteLine(current.Value.property2);
                    current = current.Next;
                }
            }
    
            public void Test3()
            {
                Console.WriteLine("Test3");
                _genericLinkedListOfMyObjects = new LinkedList<MyObject>();
                _genericLinkedListOfMyObjects.AddFirst(new MyObject{ property1="Prop1 Test1", property2="Prop2 Test1" });
                _genericLinkedListOfMyObjects.AddFirst(new MyObject{ property1="Prop1 Test2", property2="Prop2 Test2" });
    
                LinkedListNode<MyObject> current = _genericLinkedListOfMyObjects.First;
                foreach (var item in _genericLinkedListOfMyObjects)
                {
                    MyObject myObj = item as MyObject; //NOPE!
                    Console.WriteLine(myObj.property1);
                    Console.WriteLine(myObj.property2);
                }
            }
        }
    }
