    Wrapper w1 = new Wrapper { TheDate = DateTime.Now };
    Wrapper w2 = new Wrapper { TheDate = DateTime.Now.AddYears(10) };
    
    Wrapper w;
    if (something)
    {
        w = w1;
    }
    else
    {
        w = w2;
    }
    w.DoSomething();
    
    class Wrapper
    {
        public DateTime TheDate { get; set; }
        public void DoSomething()
        {
        }
    }
