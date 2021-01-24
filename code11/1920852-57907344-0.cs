    @code{
        public DataModel model = new DataModel();
    
        public async Task SomeAsync()
        {
            // Do some stuff with data
            // Adding new data to a model
            // Or getting something from a DB asynchronously
            model.Email = "Email@email.com";
            model.Name = "Tim";
    
            // call the view update
            this.StateHasChanged();
        }
    }
