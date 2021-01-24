    public static Expression<Func<ApplicationUser, SearchResultItemViewModel>> Projection(int parm)
        => item => new SearchResultItemViewModel
            {
                Id = item.Id,
                Article = item.FirstName + parm.ToString()
            };
