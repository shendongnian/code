    class A
    {
       public EventHandler SelectionChanged;
    
       public void TriggerSelectionChanged()
       {
          if (SelectionChanged != null) SelectionChanged(this, EventArgs.Empty);
       }
    }
    
    class B
    {
       public B()
       {
         this._a.SelectionChanged += (o, s) => 
         {
           if(this.SelectionChanged != null) { this.SelectionChange(o, s); }
         };
       }
  
   
    private A _a = new A();
    
       public A A { get { return _a; } }
    
       public EventHandler SelectionChanged;
       public static void Test()
       {
          B relayer = new B();
          bool wasRelayed = false;
          relayer.SelectionChanged += delegate { wasRelayed = true; };
          relayer.A.TriggerSelectionChanged();
          System.Console.WriteLine("Relayed: {0}", wasRelayed);
       }
   }
