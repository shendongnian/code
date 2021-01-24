    public class Farm : Building {
        public override string Name => "Farm"; // assuming c# 6.0
        public override short Id => 0;
        private Crop crop;
        // other farm-specific things
        public override void Update {
            // you access a private field,
            // but Update method itself can be called even if you don't know the type
            // every building has its own implementation
            crop.Grow ();
            // other farm-specific things
        }
    // override other methods, feel free to access private members of Farm here
    }
