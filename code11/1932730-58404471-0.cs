    var block1 = new TransformBlock<Stream, BitmapFrame>(stream =>
    {
        BitmapFrame bf = BitmapFrame.Create(stream);
        RenderOptions.SetBitmapScalingMode(bf, BitmapScalingMode.LowQuality);
        return bf;
    }, new ExecutionDataflowBlockOptions()
    {
        BoundedCapacity = 5
    });
    var block2 = new TransformBlock<BitmapFrame, int[]>(bf =>
    {
        var pixels = new int[width * height * 4];
        bf.CopyPixels(new Int32Rect(0, 0, width, height), pixels, width * 4, 0);
        return pixels;
    }, new ExecutionDataflowBlockOptions()
    {
        BoundedCapacity = 5
    });
    var block3 = new ActionBlock<int[]>(pixels =>
    {
        DisplayWrapper.USBD480_DrawFullScreenBGRA32(ref disp, pixels);
    }, new ExecutionDataflowBlockOptions()
    {
        BoundedCapacity = 5
    });
