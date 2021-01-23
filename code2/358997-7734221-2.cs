    AsfFile asfFile = new AsfFile(@"D:\samples\sample.wmv");
    AsfFileProperties fileProperties = asfFile.GetAsfObject<AsfFileProperties>();
    TimeSpan duration = TimeSpan.FromTicks((long)fileProperties.PlayDuration) - TimeSpan.FromMilliseconds(fileProperties.Preroll);
    var streamProps = asfFile.GetAsfObjects<AsfExtendedStreamProperties>()
                             .SingleOrDefault(x => x.StreamNumber == asfFile.PacketConfiguration.AsfVideoStreamId);
    double timePerFrame = streamProps.AvgTimePerFrame / (double) 10000000 ;
    double offset = 0;
    while (offset < duration.TotalSeconds)
    {
        using (var bitmap = AsfImage.FromFile(@"D:\samples\sample.wmv").AtOffset(offset))
        {
            if(bitmap!=null)
                bitmap.Save(string.Format(@"d:\Frames\{0}.jpg", offset.ToString("N")), ImageFormat.Jpeg);
        }
        offset += timePerFrame;
    }
