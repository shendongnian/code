    public JsonResult getvarelinje2(string[] items) 
    {
        var temp = new List<byte[]>(); // Create a list for handle each array
        temp.AddRange(items.Select(i => Encoding.Unicode.GetBytes(i))); // Converts each string into one byte array
        // Here you needs to find if there is a better way to compare two byte arrays.
        var _getItemsLine = db.namespace.Where(s => temp.Contains(s))  
                    .ToList();
        return Json(_getItemsLine, JsonRequestBehavior.AllowGet);
    }
