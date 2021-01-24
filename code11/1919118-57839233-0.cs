    var observations = colors
                        .Select(s => new double[] { s.R, s.G, s.B })
                        .ToArray();
    
    var kmeans = new Accord.MachineLearning.KMeans(k: colorCount);
    
    var clusters = kmeans.Learn(observations);
    
    var palette = new List<System.Drawing.Color>();
    
    foreach (var c in clusters)
    {
        var col = System.Drawing.Color.FromArgb(
    
            (int)Math.Round(c.Centroid[0], 0),  //R
            (int)Math.Round(c.Centroid[1], 0),  //G
            (int)Math.Round(c.Centroid[2], 0)   //B
        );
    
        palette.Add(col);
    }
    
    return palette.ToArray();
