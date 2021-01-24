    class Transport
    {
        public double _distance;
        Dictionary<int, Marchandise> _listeMarchandise = new Dictionary<int, Marchandise>();
        public void Ajout(Marchandise merchandise)
        {
            _listeMarchandise[merchandise.Id] = merchandise;
        }
    }
