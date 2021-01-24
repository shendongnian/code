    class NodeTemplateSelector : DataTemplateSelector
    {
      public DataTemlplate CategoryNodeTemplate { get; set; }
      public DataTemlplate FruitNodeTemplate { get; set; }
      public override DataTemplate SelectTemplate(object item, DependencyObject container)
      {
        switch (item)
        {
            case Category _:
               return this.CategoryNodeTemplate;
            case Fruit _:
               return this.FruitNodeTemplate;
            default:
               return this.FruitNodeTemplate;
        }
      }
    }
