    public class Category : IEquatable<Category>
    {
        public string MainCategory { get; set; }
        public string SubCategory { get; set; }
        public string SubSubCategory { get; set; }
        private string GetCharacterizer()
        {
            return $"{MainCategory}#{SubCategory}#{SubSubCategory}";
        }
        public override int GetHashCode()
        {
            return GetCharacterizer().GetHashCode();
        }
        public bool Equals(Category other)
        {
            if (other == null)
            {
                return false;
            }
            return GetCharacterizer().Equals(other.GetCharacterizer());
        }
        public override bool Equals(object other)
        {
            if (!(other is Category catOther))
            {
                return false;
            }
            return Equals(catOther);
        }
    }
