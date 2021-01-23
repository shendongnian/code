    class Human
    {
         public string HairColor { get; set; }
         public virtual void Talk()
         {
             Console.WriteLine("I am a human");
         }
    }
    
    class Female : Human
    {
         public virtual void Talk()
         {
             Console.WriteLine("I am a woman");
         }
    }
    
    class Male : Human
    {
         public virtual void Talk()
         {
             Console.WriteLine("I am a man");
         }
    }
    
    class Boy : Male
    {
         public virtual void Talk()
         {
             Console.WriteLine("I am a boy");
         }
    }
    
    class Girl : Female
    {
         public virtual void Talk()
         {
             Console.WriteLine("I am a girl");
         }
    }
