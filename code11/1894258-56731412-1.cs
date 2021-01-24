    class Bar
    {
        public void OnClick()
        {
            Foo foo = new Foo();
            Random rand = new Random();
            int number = rand.Next(2);
            if(number == 0)
                foo.Random1();
            if(number == 1)
                foo.Random2();
        }
    }
    class Foo
    {
        public void Random1()
        {
            
        }
        public void Random2()
        {
        }
    }
