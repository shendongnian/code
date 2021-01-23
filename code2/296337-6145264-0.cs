    try
    {
        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(message);
        }
    }
    catch(Exception ex)
    {
       // Handle exception
    }
