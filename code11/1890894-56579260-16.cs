    namespace Engine
    {
        public class Engine1
        {
            public static event OpenFormEventHandler OpenForm;
    
            public Engine1()
            {
                var obj1 = new object();
                var obj2 = new object();
                OpenFormEventArgs e = new OpenFormEventArgs() { Obj1 = obj1, Obj2 = obj2 };
                OpenForm?.Invoke(this, e);
            }
        }
    }
