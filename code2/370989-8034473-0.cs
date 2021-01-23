    public class Test
    {
        private static Test instance_ = new Test();
        MyObject q1 = new MyObject();
        MyObject q2 = new MyObject();
        MyObject q3 = new MyObject();
        MyObject q4 = new MyObject();
    
        Timer t1 = new Timer();
        Timer t2 = new Timer();
        Timer t3 = new Timer();
    
        AnotherClass a1 = new AnotherClass();
        AnotherClass a2 = new AnotherClass();
        AnotherClass a3 = new AnotherClass();
        public Test Instance { get { return instance_; } }
    }
