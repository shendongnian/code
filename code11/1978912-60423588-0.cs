    class Dreptunghi
    {
        private int x, y, w, h;
        private string denumire;
        public Dreptunghi Clone()
        {
            // Return a new instance of this class, with all  
            // properties set to the same values as this instance
            return new Dreptunghi {x = x, y = y, w = w, h = h, denumire = denumire};
        }
    }
    class Desen
    {
        public List<Dreptunghi> listaDrept = new List<Dreptunghi>();
        public Desen Clone()
        {
            // Return a new instance of this class, with a new list containing 
            // cloned instances of the original Dreptunghi list members
            return new Desen {listaDrept = listaDrept?.Select(d => d.Clone()).ToList()};
        }
    }
