        foreach (var item in items) {
            string category = CategoryList
              .FirstOrDefault(n => n == item.name);
            if (null == category) // we don't have category
                continue;
            newItems.Add(new object
              {
                  Name      = item.name,
                  Category  = category,
                  AddedTime = DateTime.Now
              });
        }
