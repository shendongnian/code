    public static class DbSetExtensions
    {
        public static List<SelectListItem> AsSelectList<T>(this DbSet<T> dbSet) where T : class, IBaseSelectItem
        {
            return dbSet
                .Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name })
                .ToList();
        }
    }
