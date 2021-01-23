    class a 
    {
        public event Action foo;
        b zzz = new b();
        public a()
        {
            // this allow you to achieve point (1)
            foo += zzz.FireBarEvent;
            // this allow you to achieve point (2)
            zzz.bar += OnBar;
        }
        void OnBar()
        {
            FireFooEvent();
        }
        void FireFooEvent()
        {
            if(foo != null)
                foo();
        }
    }
    
    class b 
    {
        public event Action bar;
        public void FireBarEvent()
        {
           if(bar != null)
               bar();
        }
    }
