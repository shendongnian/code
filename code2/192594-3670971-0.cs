    public class MyClass<T>
    {
            public T this[int index]
            {
                get
                {
                    ...
                }
                set
                {
                    ...
                }
            }
    
            public void MyMethod()
            {   
                 int middleIndex = ...;              
                 T value = this[middleIndex ];     
                 ...             
            }           
    }
