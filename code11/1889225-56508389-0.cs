    class Transport
    {
        public double _distance;
        List<Marchandise> _listeMarchandise = new List<Marchandise>();
        public void Ajout(Marchandise marchandise)
        {
            if (_listeMarchandise.Any(it => it.Id == marchandise.Id)) {
                // it already exists, do something about it.
            }
            // add fonction with duplicate check for ID     
        }
    }
