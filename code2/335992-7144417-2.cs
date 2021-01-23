    class CmsCategory_SortByName : IComparer<CmsCategory>
    {
        #region IComparer<CmsCategory> Members
        
        public int Compare( CmsCategory x, CmsCategory y )
        {
            return string.Compare( x.Name, y.Name );
        }
        
        #endregion
    }
    var customSort = new CmsCategory_SortByName();
    categories.Sort(customSort);
