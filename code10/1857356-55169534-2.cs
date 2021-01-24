    class CatInfo : Tuple<string, string, string> {
        public string Category => Item1;
        public string SubCategory => Item2;
        public string SubSubCategory => Item3;
        public CatInfo(string cat, string subCat, string subSubCat) : base(cat, subCat, subSubCat) { }
    }
