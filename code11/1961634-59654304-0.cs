using System;
namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            VirtualTest test1 = new Test1();
            test1.ParentMethod();
            VirtualTest test2 = new Test1();
            test2.ParentMethod();
            Console.ReadKey();
        }
    }
    abstract class VirtualTest
    {
        public void ParentMethod()
        {
            try
            {
                ChildMethod();
            }
            catch
            {
                Console.WriteLine("parent");
            }
        }
        protected abstract void ChildMethod();
    }
    class Test1 : VirtualTest
    {
        protected override void ChildMethod()
        {
            try
            {
                throw new ArgumentException("A message");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw; //Here is a way to handle more specificly some
                //errors but still throwing and keeping the original stacktrace
            }
        }
    }
    class Test2 : VirtualTest
    {
        protected override void ChildMethod()
        {
            throw new NotImplementedException();
        }
    }
}
In that case you also have more control of what you're catching at which level and you can decide wether you want to deal with it or not.  
The finer level you handle the `Exception` the better.
Also in that example `Parents` are actually parents and `Children` are actually childrend in a POO way.
