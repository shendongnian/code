using System;
using System.Collections.Generic;
using System.Reflection;
My full code:
using System;
using System.Collections.Generic;
using System.Reflection;
namespace cant_dynamically_invoke_a_method_in_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Test.InvokeStuff();
        }
    }
    public class P_WATER
    {
        private int[] jDS = new int[20];
        private int n;
        public int[] JDS { get => jDS; set => jDS = value; }
        public int N { get => n; set => n = value; }
        public void P_WATER1()
        {
            //something...
            Console.WriteLine("Success!");
        }
    }
    public class Test
    {
        public static void InvokeStuff()
        {
            // Needed to mock this up
            List<P_WATER> PLibStateList = new List<P_WATER>();
            P_WATER P_WATERState1 = new P_WATER();
            PLibStateList.Add(P_WATERState1);
            // Try to invoke methods from each objects.
            foreach (object item in PLibStateList)
            {
                Type objType = item.GetType();
                objType.InvokeMember(objType.Name + "1", BindingFlags.InvokeMethod, null, item, null);
            }
        }
    }
}
Entered the method successfuly:
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/ojZtv.png
Regards!
