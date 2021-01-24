    public SelectionViewModel(Item datasource)
    {
        if (datasource.HasChildren)
        {
            Descriptions = datasource.Children
                .InnerChildren
                .Where(item => 
                    TemplateManager.GetTemplate(item).InheritsFrom(Template.Info.Id))
                .Select(item => item[Template.Info.Field.Information]).ToArray();
        }
    }
