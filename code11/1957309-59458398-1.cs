    internal class MyObject
        {
            public char Modifier { get; set; }
            public string Name { get; set; }
            public string Type { get; set; }
            //When i add this to my class.
            public override bool Equals(object obj)
            {
                return this.Name == ((MyObject)obj).Name;
            }
        }
