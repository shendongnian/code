    public class Test {
        .cctor {    //Class constructor
            Test.test = new Test();                //Inline field initializer
            Console.WriteLine("static Test()");    //Explicit static ctor
        }
        .ctor { ... }    //Instance constructor
    }
