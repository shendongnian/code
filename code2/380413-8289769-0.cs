    private XElement ConvertCategoryToListItem(XElement category)
    {
        // new list item using the 'name' element
        var result = new XElement("li", category.Element("name").Value);
        // add any sub-categories to an ul element
        if (category.Element("categories") != null)
        {
            var nestedCategories = category.Element("categories").Elements("category");
            result.Add(new XElement("ul"), nestedCategories.Select(c => 
                ConvertCategoryToListItem(c)));
        }
        return result;
    }
