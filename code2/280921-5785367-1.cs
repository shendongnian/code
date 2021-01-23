    // ... code to save Category and Content, then...
    SubCategory subCategory = new SubCategory();
    content.AddSubCategory(subCategory); // modified to *not* set LastActive
    dao.Save(subCategory);
    content.LastActive = subCategory;
    dao.Update(content);
