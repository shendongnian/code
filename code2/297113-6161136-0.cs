    var lonlats = trk.Segs.Select(
        trksegg => new[] {
            Convert.ToDouble(trksegg.Longitude),
            Convert.ToDouble(trksegg.Latitude)
        }).ToArray();
