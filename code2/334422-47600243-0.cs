    public class Foo
    {
        // cool, it can return a value! which value it returns if there're multiple 
        // subscribers? answer (by trying): the last subscriber.
        public event Func<int, string> OnCall;
        private int val = 1;
    
        public void Do()
        {
            if (OnCall != null) 
            {
                var res = OnCall(val++);
                Console.WriteLine($"publisher got back a {res}");
            }
        }
    }
    
    public class Program
    {
        static void Main(string[] args)
        {
            var foo = new Foo();
    
            foo.OnCall += i =>
            {
                Console.WriteLine($"sub2: I've got a {i}");
                return "sub2";
            };
    
            foo.OnCall += i =>
            {
                Console.WriteLine($"sub1: I've got a {i}");
                return "sub1";
            };
    
            foo.Do();
            foo.Do();
        }
    }
