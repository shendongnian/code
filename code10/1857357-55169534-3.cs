    struct CatInfo {
        public string Category { get; }
        public string SubCategory { get; } 
        public string SubSubCatergory { get; }
        public CatInfo(string cat, string subCat, string subSubCat) {
            Category = cat;
            SubCategory = subCat;
            SubSubCatergory = subSubCat;
        }
        public bool Equals(CatInfo other) {
            return string.Equals(Category, other.Category) && string.Equals(SubCategory, other.SubCategory) && string.Equals(SubSubCatergory, other.SubSubCatergory);
        }
        public override bool Equals(object obj) {
            if (obj is null)
                return false;
            return obj is CatInfo info && Equals(info);
        }
        public override int GetHashCode() {
            unchecked {
                int hashCode = (Category != null ? Category.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubCategory != null ? SubCategory.GetHashCode() : 0);
                hashCode = (hashCode * 397) ^ (SubSubCatergory != null ? SubSubCatergory.GetHashCode() : 0);
                return hashCode;
            }
        }
        public static bool operator ==(CatInfo info1, CatInfo info2) {
            return info1.Equals(info2);
        }
        public static bool operator !=(CatInfo info1, CatInfo info2) {
            return !(info1 == info2);
        }
    }
