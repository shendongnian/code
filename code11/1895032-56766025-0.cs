    public List<SelectListItem> GetGenericList<T> (list<T> genModel, Func<T, string> textSelector, Func<T, string> valueSelector)
    {
        List<SelectListItem> lst =  new List<SelectListItem>();
        // loop through genModel, not lst!
        foreach(var model in genModel)
        {
            lst.add (new SelectListItem
            {
                Text = textSelector(model), // Note how we use the selectors here
                Value = valueSelector(model)
            });
        }
        return lst;
    }
