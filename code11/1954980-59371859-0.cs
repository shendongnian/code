    string[] lines = File.ReadAllLines(ofdl.FileName);
    var codes = lines.Where(s => !String.IsNullOrWhiteSpace(s)).ToList();
    dataGrid.ItemsSource = codes;
    under_label.Content = ofdl.FileName;
    under_label1.Content = codes.Count;
