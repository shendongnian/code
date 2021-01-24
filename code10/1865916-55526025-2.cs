using System;
using System.Collections.Generic;
namespace TestingGround
{
    public class Program
    {
        public class GenericClass<T>
        {
            public T Value;
            public GenericClass()
            {
                Value = default;
            }
        }
        static void Main(string[] args)
        {
            var gc = new GenericClass<string>();
            var strLength = gc.Value.Length;
        }
    }
}
IL
      IL_0008: ldarg.0      // this
      IL_0009: ldflda       !0/*T*/ class TestingGround.Program/GenericClass`1<!0/*T*/>::Value
      IL_000e: initobj      !0/*T*/
  [1]: https://i.stack.imgur.com/8ZPqU.png
