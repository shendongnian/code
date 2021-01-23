    var item = from r in Datatable.AsEnumerable()
                where r.Field<int>("SerialNumber") == int.Parse(SearchTextbox.Text.ToString())
                select r.Field<int>("SerialNumber");
    
    if (item == null)
    {
       // not found
    }
    else
    {
       // you found it. 
    }
