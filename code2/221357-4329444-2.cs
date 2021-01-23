    public Temp()
    {
      InitializeComponent();
    
      Mediator.Instance.Register
      (
          "Category Selected",
          OnCategorySelected
      );
    }
    
    private void OnCategorySelected(object parameter)
    {
      var selectedCategory = parameter as Category;
      
      if(selectedCategory != null)
      {
      }
    }
 
