    private async Task readCSVCustomAsync()
    {
        ApplicationDataContainer localSettings = ApplicationData.Current.LocalSettings;
        StorageFile file;
        FileOpenPicker openPicker = new FileOpenPicker();
        openPicker.SuggestedStartLocation = PickerLocationId.Desktop;
        openPicker.FileTypeFilter.Add("*");
        //picking a file with FilePicker
        file = await openPicker.PickSingleFileAsync();
        //Storing file in futureaccesslist
        string faToken = StorageApplicationPermissions.FutureAccessList.Add(file);
    
        //getting the file from FA list
        var fileOpenTest = await StorageApplicationPermissions.FutureAccessList.GetFileAsync(faToken);
         // open file as stream, to avoid using path property
        var stream = await fileOpenTest.OpenStreamForReadAsync();
        //trying to read it
        using (var reader = new StreamReader(stream)) 
        using (var csv = new CsvReader(reader))
        {
            //elimination des premieres lignes avant le header
            bool headerOK = false;
            while (csv.Read() && !headerOK)
            {
                string rec = csv.GetField(0) + csv.GetField(1);
                if (!rec.Equals(""))
                {
                    csv.ReadHeader();
                    headerOK = true;
                }
            }
        }
    }
