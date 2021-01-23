    // This is a lazy class - but you can have more than one
    class Lazy
    {
        private int? value;
        public int Value {
            get
            {
               return value ?? value = Random.Next ();
            }
        }
    }
