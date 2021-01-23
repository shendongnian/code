    //WindowMain.tvTemplateSolutions.ItemsSource = this.Context.Solutions.Local.Where(obj=>obj.IsTemplate); // templates
    ICollectionView viewTemplateSolution = CollectionViewSource.GetDefaultView(this.Context.Solutions.Local);
    viewTemplateSolution.SortDescriptions.Clear();
    viewTemplateSolution.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
    viewTemplateSolution.Filter = obj =>
    {
       Solution solution = (Solution) obj;
       return solution.IsTemplate;
    };
    WindowMain.tvTemplateSolutions.ItemsSource = viewTemplateSolution;
