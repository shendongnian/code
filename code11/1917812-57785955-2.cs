    using (var context = new MyContext())
    {
        // Get the object from the table (in this case I give an example to get the first row. You can use Where for the condition)
        var row = context.MyTable.FirstOrDefault();
        // Get the field value with reflection
        response = row.GetType().GetProperty(name).GetValue(row, null).ToString();
    }
