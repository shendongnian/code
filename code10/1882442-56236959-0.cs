    class Program
    {
        static void Main(string[] args)
        {
            Cat cat1 = new Cat(SomeClass.DoSound1);
            Cat cat2 = new Cat(SomeClass.DoSound2);
            CatObservable cat3 = new CatObservable();
            cat3.Sound += Cat3_Sound;
            cat3.Sound += (object sender, EventArgs e) => { SomeClass.DoSound1(); } ;
            cat3.Sound += (object sender, EventArgs e) => { SomeClass.DoSound2(); };
        }
        private static void Cat3_Sound(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    public class Cat
    {
        public delegate void SoundDelegate();
        public SoundDelegate Sound { get; set; }
        
        public Cat(SoundDelegate soundDelagate)
        {
            Sound = soundDelagate;
        }
        protected void DoSound()
        {
            if (Sound!=null)
                Sound();
        }
    }
    public class CatObservable
    {
        public event EventHandler Sound;
        public CatObservable()
        {
        }
        protected void DoSound()
        {
            if (Sound != null)
                Sound(this, EventArgs.Empty);
        }
    }
    public class SomeClass
    {
        public static void DoSound1()
        {
            Console.WriteLine("Sound 1");
        }
        public static void DoSound2()
        {
            Console.WriteLine("Sound 2");
        }
    }
