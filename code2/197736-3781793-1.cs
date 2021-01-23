    using (var file = System.IO.File.OpenText("data.txt"))
    {
       string line;
       while ((file.ReadLine()) != null)
       {
           string[] parts = line.Split('=');
           string key = parts[0];
           string value = parts[1];
           // use it
       }
    }
