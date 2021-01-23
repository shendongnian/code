    internal class Class1
    {
        public class Class2
        {
            /// <summary>
            /// Gets or sets the name of the customer. 
            /// </summary>
            internal string Name
            {
                get { return this.name; }
                protected set { this.name = value; }
            }
        }
        private class Class3 : Class2
        {
            public Class3(string name) { this.Name = name; }
        }
    }
