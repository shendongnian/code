    List<int> listValues = new List<int>();
    foreach (string key in Request.Form.AllKeys)
    {
        if (key.StartsWith("List")
        {
            listValues.Add(Convert.ToInt32(Request.Form[key]));
        }
    }
