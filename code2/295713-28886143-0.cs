        public class Veg
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public bool Fruit { get; set; }
        }
        enum Mode
        {
            One,
            Two,
            Three
        }
        static void Main()
        {
            Mode mode = Mode.One;
            var data = new List<Veg>
            {
                new Veg{Id = 1, Name = "Apple", Fruit = true},
                new Veg{Id = 2, Name = "Carrot", Fruit = false}
            };
            var dataSelect = data.Where(w => (mode == Mode.One && w.Fruit) || //only fruits
                                             (mode == Mode.Two && !w.Fruit) || //only not fruits
                                             (mode == Mode.Three)); //all of it
        }
