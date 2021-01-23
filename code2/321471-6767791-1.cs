        public class MyType
        {
            /// <summary>
            /// Need a constructor since we're using properties
            /// </summary>
            public MyType()
            {
                this.A = new int();
                this.B = string.Empty;
                this.C = new ushort();
            }
            public int A
            {
                get;
                set;
            }
            public string B
            {
                get;
                set;
            }
            public ushort C
            {
                get;
                set;
            }
        }
