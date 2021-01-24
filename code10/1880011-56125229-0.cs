    string line;
    while ((line = sr.ReadLine()) != null) {
     if (!(line.Contains("#"))) {
        string[] columns = line.Split(';');
        //this two line are to make sure we have date on the field if you sure its date you can just use this: DateTime.Parse(columns[0]).ToString("yyyy-MM-dd");
        DateTime dateTry = new DateTime();
        DateTime.TryParse(columns[0], out dateTry);
        datatable1.Rows.Add(dateTry.ToString("yyyy-MM-dd"), columns[1], columns[2], columns[3]);    
    }                   
    bindingsource1.DataSource = datatable1;
    adgv.DataSource = bindingsource1;
