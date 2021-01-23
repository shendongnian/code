    double[,] lonlat = new double[trk.Segs.Length, 2];
    for (int i=0; i<trk.Segs.Length; i++) {
        lonlat[i,0] = Convert.ToDouble(trk.Segs[i].Longitude);
        lonlat[i,1] = Convert.ToDouble(trk.Segs[i].Latitude);
    }
