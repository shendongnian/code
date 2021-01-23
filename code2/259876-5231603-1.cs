    class AnotherClass
    {
        void method2()
        {
            Program p = new Program();
            p.i = 5; //error because private variables cannot be accessed with an object which is created out side the class
        }
    }
