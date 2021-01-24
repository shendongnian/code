    for (int i = 0; i < gif.Frames.Count; i++)
    {
        ImageFrame<Rgba32> frame = gif.Frames[i];
        GifFrameMetaData frameMetaData = frame.MetaData.GetFormatMetaData(GifFormat.Instance);
        Console.WriteLine($"Delay for frame #{i} is {frameMetaData.FrameDelay}");
    }
