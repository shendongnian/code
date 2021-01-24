        try
        {
            FileData fileData = await CrossFilePicker.Current.PickFile();
            if (fileData == null)
                return; // user canceled file picking
            string fileName = fileData.FileName;
            string contents = System.Text.Encoding.UTF8.GetString(fileData.DataArray);
            System.Console.WriteLine("File name chosen: " + fileName);
            System.Console.WriteLine("File data: " + contents);
        }
        catch (Exception ex)
        {
            System.Console.WriteLine("Exception choosing file: " + ex.ToString());
        }
