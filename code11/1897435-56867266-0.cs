        foreach (var item in items) {
            string category = CategoryList
              .Where(n => n == item.name)
              .FirstOrDefault();
            if (null == category) // we don't have category
                continue;
            newItems.Add(new object
              {
                  Name      = item.name,
                  Category  = category,
                  AddedTime = DateTime.Now
              });
        }
