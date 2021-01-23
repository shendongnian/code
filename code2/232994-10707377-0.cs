            List<Category> categories = db.GetCategory();
            for (int i = 0; i < categories.Count; i++)
            {
                ((Menu)sender).Items.Add(new MenuItem(categories.ElementAt(i).Name));
            }
        } 
