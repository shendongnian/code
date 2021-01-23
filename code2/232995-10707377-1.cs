        protected void Menu1_Init(object sender, EventArgs e)
        {
            List<Category> categories = db.GetCategory();
            for (int i = 0; i < categories.Count; i++)
            {
                ((Menu)sender).Items.Add(new MenuItem(categories.ElementAt(i).Name));
            }
        } 
