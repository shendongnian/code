    public  class Animal
    {
        public Animal()
        {
            Speak();
        }
      public virtual void Speak()
      {
          Console.WriteLine("Animal speak");
      }
    }
    public  class Dog:Animal
    {
        private StringBuilder sb = null;
        public Dog()
        {  }
        public override void Speak()
        {
            if(sb==null) { sb = new StringBuilder(); }    // lazy init
            sb.Append("bow");
            Console.WriteLine("bow...{0}",sb.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Dog d=new Dog();
        }
    }
}
