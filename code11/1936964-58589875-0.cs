    // set the BindingContext for the page
    this.BindingContext = new MyViewModel();
    
    // Title is a public property on MyViewModel
    myLabel.SetBinding(Label.TextProperty, "Title");
