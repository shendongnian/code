    public void AfterRead(AfterReadEventArgs<RawVolsDataPoints> e)
    {
        var record = (Product)e.Record;
        if (PreviousRecord == null)
        {
            PreviousRecord = new Product();
             PreviousRecord = record;
        }
        if (String.IsNullOrEmpty(record.ID)) // null value indicates a new row
        {
            var ttype = typeof(Product);
            var fields = ttype.GetFields();
            var fieldsToCopy = fields.Where(field =>
                field.GetCustomAttributes(typeof(CopyMeAttribute), true).Any());
            foreach (var item in fieldsToCopy)
            {
                var prevvalue = item.GetValue(PreviousRecord);
                item.SetValue(record, prevvalue);
             }
        }
    }
