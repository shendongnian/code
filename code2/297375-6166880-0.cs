    var dialog = openFileDialog1;
    if (dialog == null)
    {
        MessageBox.Show("openFileDialog1 is null");
    }
    var filename = dialog.FileName;
    if (filename == null)
    {
        MessageBox.Show("openFileDialog1.FileName is null");
    }
    InstrumentDescription input;
    try
    {
        input = InstrumentDescription.Load(filename);
    }
    catch (NullReferenceException e)
    {
        MessageBox.Show("NullReferenceException in InstrumentDescription.Load():\n" + e.Message);
    }
    if (input == null)
    {
        MessageBox.Show("inputFile is null");
    }
    var id = input.Identification;
    if (id == null)
    {
        MessageBox.Show("inputFile.Identification is null");
    }
    var mans = id.Manufacturers;
    if (mans == null)
    {
        MessageBox.Show("inputFile.Identification.Manufacturers is null");
    }
    var man = mans.Manufacturer;
    if (man == null)
    {
        MessageBox.Show("inputFile.Identification.Manufacturers.Manufacturer is null");
    }
    var i = 0L;
    foreach (var dm in man)
    {
        if (dm == null)
        {
            MessageBox.Show("dataManufaturer at index "+i+" is null");
        }
        if (dm.name == null)
        {
            MessageBox.Show("dataManufaturer.name at index " + i + " is null");
        }
        if (dm.cageCode == null)
        {
            MessageBox.Show("dataManufaturer.cageCode at index " + i + " is null");
        }
        if (dm.FaxNumber == null)
        {
            MessageBox.Show("dataManufaturer.FaxNumber at index " + i + " is null");
        }
        var u = dm.URL;
        if (u == null)
        {
            MessageBox.Show("dataManufaturer.URL at index " + i + " is null");
        }
        if (u.OriginalString == null)
        {
            MessageBox.Show("dataManufaturer.URL.OriginalString at index " + i + " is null");
        }
        i++;
    }
