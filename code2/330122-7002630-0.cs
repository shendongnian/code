    bloblist.Select(item => new { X = item.Rectangle.X, Y = item.Rectangle.Y })
            .OrderByDescending(item => item.X)
            .ToList()
            .ForEach(item =>
            {
                listBox1.Items.Add(item.X + " " + item.Y);
            });
    
