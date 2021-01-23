    foreach(var pair in sequence.Images
                        .Select(im1 => 
                                  sequence.Images.Select(im2 => Tuple.Create(im1, im2))
                        .Where(pair => pair.Item1 != pair.Item2))
    {
        metric.SetImageMetric(new ImagePair(pair.Item1, pair.Item2), 1.0);
    }
