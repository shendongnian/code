    int[] indices = Request.Form.AllKeys.Where(k => k.StartsWith("CategoryID-")).Select(k => Convert.ToInt32(k.Substring(11))).ToArray();
    foreach (int index in indices)
    {
        string cat = Request.Form["CategoryID-" + index.ToString()];
        string subcat = Request.Form["SubCategoryID-" + index.ToString()];
        //etc.
      
    }
