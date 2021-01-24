        static void Main(string[] args)
        {
            var a = Enumerable.Range(1, 5).Select((i) => i).ToArray();
            // [1,2,3,4,5]
            var b = Enumerable.Range(4, 5).Select((i) => i).ToArray();
            // [4,5,6,7,8]
            var c = ComposeArray(a, b);
            // [9,9,9,9,9]
        }
