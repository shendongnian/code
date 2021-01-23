        using System;
 
        class Class_name
        {
            
            
            static  string static_variable="static";
             
            string instance_variable="instance";
            static void Main()
            {
                Class_name object_name = new Class_name();
                Console.WriteLine("Printing out instance and static variables from within Main() body :");
                Console.WriteLine(object_name.instance_variable);
                Console.WriteLine(Class_name.static_variable);
                /* Note that we cannot say either of the following :
                  
                        object_name.static_variable 
                        Class_name.instance_variable
                */
                Console.WriteLine();
                // now lets call the static and instance methods
                object_name.Instance_method(); // Now this is the key call which 
                // passes "this" as an invisible parameter 
                // to the Instance_method. "this" refers to  
                //  object_name
                Class_name.Static_method();//  "this" is NOT passed to Static_method() because now 
                // the call is made on Class_name ... so there is nothing
                // to be represented by "this"
                Console.ReadLine();
            }
            
            void Instance_method()
            { 
                // here we receive "this" as an invisible parameter referring 
                // to the object on which  Instance_method is called (i.e. object_name)...
                // ... see the Main() method for comments at the call site. 
                Console.Write("Instace method called ... " +
                                "prints out instance variable twice, with and without 'this': ");
                
                // the following two calls mean exactly the same.
                Console.Write(this.instance_variable);
                Console.WriteLine (instance_variable);
                // one little additional point is that static members are 
                // accessible from within instance members
                Console.WriteLine();
                Console.Write("static variables can also be accessed from within Instance_method: ");
                Console.WriteLine(static_variable);
                Console.WriteLine();
                Console.WriteLine();
                
              
             
            
            }
            static void Static_method()
            {
                // See the Main() method body for the call Class_name.Static_method()
                // Notice that this method is called on Class_name and not object_name
                // which means that there is no invisibly passed-in "this" parameter available
                // in this method. 
                // we can also not access the instance_variable in this method 
                // as instance variables are always part of some object. This method
                // is not called on any object, its called on Class_name.
                // Console.WriteLine(instance_variable); // Compiler error
                Console.WriteLine("Static method called ... prints out static variable: ");
                Console.WriteLine(static_variable);
            }
           
        }
 
