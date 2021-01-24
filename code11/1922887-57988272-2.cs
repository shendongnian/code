    List<Category> list = new List<Category>(); 
    using (var reader = count_categories.ExecuteReader()) {
      while (reader.Read()) {
        //TODO: put the right syntax here
        Category category = new Category() {
          Name = Convert.ToString(reader["Name"]),
        };  
        list.Add(category);
      }
    }
