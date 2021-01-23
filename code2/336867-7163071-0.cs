    private void getcategorynames() {
        age.Categories.ToList().ForEach((c) => listcategories.Items.Add(c));
        listcategories.SelectedIndexChanged += (sender, e) => {
            Category category = (Category)listcategories.SelectedItem;
            // Do something with category.Id
        };
    }
