    namespace MVCApplication7
    {
        public class Something
        {
            public int SomethingID { get; set; }
            public string Name { get; set; }
            public List<Color> Colors { get; set; }
            public Something()
            {
                this.Colors = new List<Color>(); 
            }
        }
    }
