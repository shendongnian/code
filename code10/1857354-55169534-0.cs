    class CatInfo : Tuple<string, string, string> {
        public string Category => Item1;
        public string SubCategory => Item1;
        public string SubSubCategory => Item1;
        public CatInfo(string cat, string subCat, string subSubCat) : base(cat, subCat, subSubCat) { }
    }
