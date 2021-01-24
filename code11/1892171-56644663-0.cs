    Parallel.ForEach(Partitioner.Create(0, data.Length), range =>
    {
        for (int j = range.Item1; j < range.Item2; j++)
        {
            var x = (location.X + (j % width));
            var y = (location.Y + (j / width));
            Vector3 p = new Vector3(x, y, frame);
            p *= zoom;
            float val = noise.GetNoise(p);
            data[j] += val;
            min = Math.Min(min, val);
            max = Math.Max(max, val);
        }
    });
