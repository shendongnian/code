        public List<Artikel> ArtikelList { get; private set; }
        public void Add(Artikel artikel)
        {
            if (ArtikelList == null)
                ArtikelList = new List<Artikel>();
            ArtikelList.Add(artikel);
        }
