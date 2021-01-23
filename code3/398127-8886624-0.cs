            Item item = new Item();
            item.Category = category;
            item.ItemId = ...
            foreach(var categoryItemProperty in category.ItemProperties)
            {
                ItemProperty itemProperty = new ItemProperty();
                itemProperty.Item = item;
                itemProperty.CategoryItemProperty = categoryItemProperty;
                itemProperty.ItemPropertyId = ... 
            }
            return item;
        }
