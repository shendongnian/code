    public class MyClass
    {
        public animal MyAnimal { get; private set; }
        public MyClass ()
        {
            MyAnimal = new dog ();
        }
        public void SetAge (int Age)
        {
            ((dog)MyAnimal).age = Age;
        }
    }
