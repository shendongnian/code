    namespace ObjectReference    
    {    
        public class B<TypeC>    
        {   
            public A<TypeC> a;
        
            public B(A<TypeC> myObjA)    
            {    
                a = myObjA;   
            }
        }    
    }
