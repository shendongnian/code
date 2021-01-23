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
         public override void Talk()
         {
             Console.WriteLine("I am a woman");
         }
    }
    
    class Male : Human
    {
         public override void Talk()
         {
             Console.WriteLine("I am a man");
         }
    }
    
    class Boy : Male
    {
         public override void Talk()
         {
             Console.WriteLine("I am a boy");
         }
    }
    
    class Girl : Female
    {
         public override void Talk()
         {
             Console.WriteLine("I am a girl");
         }
    }
