    ObservableCollection<Product> products = new ObservableCollection<Product>();
            products.Add(new ProgrammingBook() { BookName = "P1", LanguageCovered = "C#" });
            products.Add(new ProgrammingBook() { BookName = "P2", LanguageCovered = "F#" });
            products.Add(new RecipeBook() { BookName = "P3", NumRecipes = 4 });
            products.Add(new RecipeBook() { BookName = "P4", NumRecipes = 6 });
            products.Add(new Disk() { Size = 512 });
            products.Add(new Disk() { Size = 1024 });
            this.DataContext = products;
