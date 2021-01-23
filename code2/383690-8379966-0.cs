    using (var sr = File.OpenText(path))
    {
      var line = string.Empty;
      while ((line = sr.ReadLine()) != null)
      {
        var dataPoints = line.Split(',');
        // Create Your Data Mappings Here
        // dataPoints[0]...
      }
    }
