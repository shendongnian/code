    class SomeClass
    {
        [MyEventInfoAttribute(EventFile = "c:\\blah\\events.foo")]
        void SomeMethod()
        {    
            Type type = typeof(SomeClass);
            MethodInfo method = type.GetMethod("SomeMethod");
            object[] atts = method.GetCustomAttributes();
            if (atts.Length > 0)
            {
                if (atts[0] is MyEventInfoAttribute)
                {
                    string fileName = ((MyEventInfoAttribute)atts[0]).EventFile;
    
                    ... now open the file, read the event info, and use it ...
                }
            }
        }
    }
