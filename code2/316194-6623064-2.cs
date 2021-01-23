    class A
    {
       public EventHandler SelectionChanged;
    
       public void TriggerSelectionChanged()
       {
          if (SelectionChanged != null) SelectionChanged(this, EventArgs.Empty);
       }
    }
    
    class B : A
    {
       public static void Test()
       {
          B relayer = new B();
          bool wasRelayed = false;
          relayer.SelectionChanged += delegate { wasRelayed = true; };
          relayer.TriggerSelectionChanged();
    
          System.Console.WriteLine("Relayed: {0}", wasRelayed);
       }
    }
