     /*interface 1 with two methods*/
        interface IA1
        {
            void Foo1();
            void Foo2();
        }	
       /*Interface two with two methods */
        interface IA2
        {
            void Foo1();
            void Foo3();
        }	
 
     /*class implemeting two interfaces now. Here class cannot inherit two classes but can inherit two interfcaes.*/
      /* Case1 */
        class CA : IA1, IA2  
        { 
            void IA1.Foo1()//Explicitly Implemented
            {
                Console.WriteLine("In IA1.Foo1");
            }
            void IA2.Foo1() //Explicitly Implemented
            {
                Console.WriteLine("In IA2.Foo1");
            }
            public void Foo2()  //Implicitly Implemented
            {
                Console.WriteLine("In IA1.Foo2");
            }
            public void Foo3()  //Implicitly Implemented
            {
                Console.WriteLine("In IA2.Foo3");
            }
        }
   
     /* Case2*/
        class CA : IA1, IA2   {
            public void Foo1() //Implicitly Implemented
            {
                Console.WriteLine("In Foo1");
            }
            public void Foo2()  //Implicitly Implemented
            {
                Console.WriteLine("In Foo2");
            }
            public void Foo3()  //Implicitly Implemented
            {
                Console.WriteLine("In Foo3");
            }
        }	
