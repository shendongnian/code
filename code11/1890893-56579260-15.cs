    namespace Engine
    {
        public class OpenFormEventArgs
        {
            public object Obj1 { get; set; }
            public object Obj2 { get; set; }
        }
    
        public delegate void OpenFormEventHandler(object sender, OpenFormEventArgs e);
    }
