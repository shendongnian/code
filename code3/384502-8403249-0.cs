    public abstract class CustomControl<T> where T : class
    { 
        private T _dataItem; 
     
        public T DataItem { 
            get { return _dataItem; } 
            set { _dataItem = value; } 
        } 
     
        public abstract void Update();
    }
    
    public class StringCustomControl : CustomControl<string>
    {
        public override void Update( )
        {
           DataItem = "test";
        }
    }
