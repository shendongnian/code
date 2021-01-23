    class Program
    {
        static void Main()
        {
            Sub0 s0 = new Sub0();
            Sub1 s1 = new Sub1();
            var sub0s = new Sub0[] { new Sub0() };
            var sub1s = new Sub1[] { new Sub1() };
            doStuff(sub0s, sub1s);
        }
        static void doStuff(params IEnumerable<ISuper>[] args)
        {
            foreach (var sequence in args)
            {
                foreach (var obj in sequence)
                    Console.WriteLine(obj.GetType());
            }
        } 
    }
    interface ISuper { }
    class Super : ISuper { }
    class Sub0 : Super { }
    class Sub1 : Super { }  
