        public static void CallDoSomething(object o)
        {
            A aObject = o as A;
            if (aObject != null)
            {
                aObject.DoSomething();
                return;
            }
            B bObject = o as B;
            if (bObject != null)
            {
                bObject.DoSomething();
                return;
            }
        }
