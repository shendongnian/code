    for (int i = 0; i < 20; i++)
    {
        var total = new Stopwatch();
        var read = new Stopwatch();
        var process = new Stopwatch();
        total.Start();
        using (var inputStream = new FileStream(@"C:\Projects\ConsoleApplication6\ConsoleApplication6\monster.jpg", FileMode.Open))
        {
            read.Start();
            var bytes = new byte[inputStream.Length];
            inputStream.Read(bytes, 0, bytes.Length);
            read.Stop();
            process.Start();
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.StreamSource = new MemoryStream(bytes);
            bitmapImage.DecodePixelWidth = 800;
            bitmapImage.EndInit();
            using (var outputStream = new MemoryStream())
            {
                var jpegEncoder = new JpegBitmapEncoder();
                var frame = BitmapFrame.Create(bitmapImage);
                jpegEncoder.Frames.Add(frame);
                jpegEncoder.Save(outputStream);
                process.Stop();
                File.WriteAllBytes(@"C:\Projects\ConsoleApplication6\ConsoleApplication6\monster" + i + ".jpg", outputStream.ToArray());
            }
        }
        total.Stop();
        Console.WriteLine("{0:0.000} ms ({1:0.000} ms / {2:0.000} ms)", total.Elapsed.TotalMilliseconds, read.Elapsed.TotalMilliseconds, process.Elapsed.TotalMilliseconds);
    }
