    class Program
    {
        static void Main()
        {
            var sub0s = new Sub0[] { new Sub0() };
            var sub1s = new Sub1[] { new Sub1() };
            doStuff(sub0s, sub1s);
        }
        static void doStuff(params IEnumerable<ISuper>[] args)
        {
            foreach (var sequence in args)
            {
                foreach (var obj in sequence)
                {
                    Console.WriteLine(obj.GetType());
                    // you have the ability to invoke any method or access 
                    // any property defined on ISuper
                }
            }
        } 
    }
    interface ISuper { }
    class Super : ISuper { }
    class Sub0 : Super { }
    class Sub1 : Super { }  
