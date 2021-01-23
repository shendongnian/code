    using (var writer = new BinaryWriter(stream)) {
        // write the number of items so we know how many to read out
        writer.Write(points.Count);
        // write three ints per point
        foreach (var point in points) {
            writer.Write(point.X);
            writer.Write(point.Y);
            writer.Write(point.Z);
        }
    }
