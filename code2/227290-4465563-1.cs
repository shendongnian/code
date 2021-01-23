    using System;
    using System.Runtime.InteropServices;
    
    public static class Foobar {
        public static void Main() {
            var strings = new[,] {
                { "The", "quick" },
                { "brown", "fox" },
                { "jumped", "over" },
                { "the", "lazy" },
                { "dog", "LOL" }
            };
    
            Foo(5, strings);
        }
    
        [DllImport("test")]
        private static extern void Foo(int count, string[,] pairs);
    }
