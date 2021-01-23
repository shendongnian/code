    class CmsCategory: IComparable<CategoryID>
    {
         public int CategoryID { get; set; }
            
         #region IComparable<CmsCategory> Members
         
         public int CompareTo( CmsCategory other )
         {
             if ( this.CategoryID < other.CategoryID ) return 1;
             else if ( this.CategoryID > other.CategoryID ) return -1;
             else return 0;
         }
            
         #endregion
    }
