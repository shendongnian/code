    public static IList<SelectListItem> AsSelectList<T>(this DbSet<T> dbSet, bool useChooseValueOption) where T : class, IBaseSelectItem
        {
            var selectList = dbSet
                .Select(c => new SelectListItem { Value = c.Id.ToString(), Text = c.Name })
                .ToList();
            if (useChooseValueOption)
                selectList.Insert(0, new SelectListItem { Value = "0", Text = "-Choose Value-" });
            return selectList;
        }
