    void Main()
    {
    	const int testIterations = 1000;
    	string imageUrl = "https://raw.githubusercontent.com/opencv/opencv/master/samples/data/orange.jpg";
    	string imagePath = Path.Combine(Path.GetTempPath(), Path.GetFileName(imageUrl));
    	using (WebClient client = new WebClient())
    	{
    		client.DownloadFile(imageUrl, imagePath);
    	}
    	using (Mat image = CvInvoke.Imread(imagePath, Emgu.CV.CvEnum.ImreadModes.Grayscale))
    	{
    		Stopwatch sw = new Stopwatch();
    		sw.Start();
    		for (int i = 0; i < testIterations; i++)
    		{
    			image.MinMax(out _, out double[] maxValues, out _, out _);
    			if (i == testIterations - 1)
    			{
    				sw.Stop();
    				Console.WriteLine($"Using Mat.MinMax: {maxValues[0]}, elapsed {sw.ElapsedMilliseconds} ms");
    			}
    		}
    		sw.Reset();
    		sw.Start();
    		for (int i = 0; i < testIterations; i++)
    		{
    
    			var max = image.GetRawData().Max();
    			if (i == testIterations - 1)
    			{
    				sw.Stop();
    				Console.WriteLine($"Using Mat.GetRawData().Max(): {max}, elapsed {sw.ElapsedMilliseconds} ms");
    			}
    		}
    		CvInvoke.Imshow("Test", image);
    	}
    }
