    private Category _SelectedCategoryA;
    public Category SelectedCategoryA
    {
       get { return _SelectedCategoryA; }
       set
       {
          if (value != _SelectedCategoryA)
          {
             _SelectedCategoryA = value;
             Items.Refresh();
          }
       }
    }
