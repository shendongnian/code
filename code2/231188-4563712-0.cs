    int i = 10;
    var radios = new[] { "", "", "" }
        .Where(path => File.Exists(path))
        .Select(path => new RadioButton
            {
                AutoSize = false,
                Image = Icon.ExtractAssociatedIcon(path).ToBitmap(),
                Height = 100,
                Width = 50,
                Location = new Point(100, (i = i + 30))
            })
         .ToArray();
    groupBox1.Controls.AddRange(radios);
