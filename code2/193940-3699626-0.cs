Thread 1                        Thread 2
int x = MyClass.StaticProperty;                                 // Let's say
                                int x = MyClass.StaticProperty; // this is 1.  
MyClass.StaticProperty = x + 1;                                 // OK, so x is
                                MyClass.StaticProperty = x + 1; // now... 2.
