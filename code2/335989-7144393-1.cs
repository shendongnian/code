    class CmsCategory : IComparable<CmsCategory>
    {
        public int CompareTo(CmsCategory other)
        {
            return this.CategoryId.CompareTo(other.CategoryId);
        }
    }
