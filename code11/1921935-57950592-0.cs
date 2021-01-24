c#
using System;
using System.Reflection;
using System.Threading;
namespace StackOverflow
{
    class Program
    {
        private static void SetName(Thread thread, string value)
        {
            //// InvalidOperationException: This property has already been set and cannot be modified.
            //thread.Name = value;
            var bindingAttr = BindingFlags.Instance | BindingFlags.NonPublic;
            var field = typeof(Thread).GetField("m_Name", bindingAttr);
            field.SetValue(thread, value);
        }
        static void Main(string[] args)
        {
            var thread = Thread.CurrentThread;
            SetName(thread, "Foo");
            SetName(thread, "Bar");
            SetName(thread, "Baz");
            SetName(thread, "Hello, StackOverflow!");
            Console.WriteLine(thread.Name);
        }
    }
}
