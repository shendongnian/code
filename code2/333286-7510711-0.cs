    public virtual PartialViewResult Menu()
    {
        var builder = new MenuModelBuilder(Context.MenuContainer);
        ViewData.Model = builder.BuildModel();
        return PartialView();
    }
