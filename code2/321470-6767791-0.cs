    using System;
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            var myType = new MyType[3];
            for (var i = 0; i < myType.Length; ++i)
            {
                myType[i].A = 0;
                myType[i].B = "1";
                myType[i].C = 2;
            }
            // alternatively, do the same with a foreach loop
            foreach (var t in myType)
            {
                t.A = 0;
                t.B = "1";
                t.C = 2;
            }
        }
        /// <summary>
        /// Since the properties are the only differentiating characteristics for array 
        /// elements, 'static' makes no sense, so I removed it.
        /// </summary>
        public class MyType
        {
            /// <summary>
            /// Gets or sets the 'a' value.
            /// </summary>
            public int A
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the 'b' value.
            /// </summary>
            public string B
            {
                get;
                set;
            }
            /// <summary>
            /// Gets or sets the 'c' value.
            /// </summary>
            public ushort C
            {
                get;
                set;
            }
        }
    }
