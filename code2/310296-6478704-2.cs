    List<CoOrd> points;
    using (var reader = new BinaryReader(stream)) {
        var count = reader.ReadInt32();
        points = new List<CoOrd>(count);
        for (int i = 0; i < count; i++) {
            var x = reader.ReadInt32();
            var y = reader.ReadInt32();
            var z = reader.ReadInt32();
            points.Add(new CoOrd(x, y, z));
        }
    }
