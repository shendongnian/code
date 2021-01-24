      public class Child1 : Parent
    {
        private int _value;
        public int Value => _value;
    
        public override void Initialize()
        {
            base.Initialize();
            _value = 1;
        }
    }
    
    public class Child2 : Parent
    {
        private double _value;
        public double Value => _value;
    
        public override void Initialize()
        {
            base.Initialize();
            _value = 1.0;
        }
    }
    
    public class Parent
    {
        private bool _initialized;
        private string _id;
        public string Id => _id;
    
        public virtual void Initialize()
        {
            if(!_initialized) 
            {
                _id = System.Guid.NewGuid().ToString();
            }
        }
    }
