     public  class GridModel
    {
        private IEnumerable<SelectList> selectList;
        private IEnumerable<SelectList> Roles;
        public GridModel()
        {
            selectList = from PageSizes e in Enum.GetValues(typeof(PageSizes))
                           select( new SelectList()
                           {
                               Id = (int)e,
                               Name = e.ToString()
                           });
            Roles= from Userroles e in Enum.GetValues(typeof(Userroles))
                   select (new SelectList()
                   {
                       Id = (int)e,
                       Name = e.ToString()
                   });
        }
      public IEnumerable<SelectList> Pagesizelist { get { return this.selectList; } set { this.selectList = value; } } 
        public IEnumerable<SelectList> RoleList { get { return this.Roles; } set { this.Roles = value; } }
        public IEnumerable<SelectList> StatusList { get; set; }
        
    }
}
