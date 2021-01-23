    private static void Test()
    {
    
        Random myRand = new Random();
    
        List<TimeSpan> convert64Times = new List<TimeSpan>();
        List<TimeSpan> cryptoTimes = new List<TimeSpan>();
        Stopwatch theTimer = new Stopwatch();
    
                
    
        for (int i = 0; i < 200; i++)
        {
    
            byte[] randBytes = new byte[1000000];
            myRand.NextBytes(randBytes);
    
            string filePrefix = @"C:\Temp\file";
    
    
            // test encode with convert to base 64
            theTimer.Start();
            EncodeWithConvertToBase64(randBytes,filePrefix+i+"convert.txt");
            theTimer.Stop();
            convert64Times.Add(theTimer.Elapsed);
            theTimer.Reset();
                    
    
            // test encode with crypto
            theTimer.Start();
            EncodeWithCryptoClass(randBytes,filePrefix+i+"crypto.txt");
            theTimer.Stop();
            cryptoTimes.Add(theTimer.Elapsed);
            theTimer.Reset();
    
        }
    }
    
            
    
    private static void EncodeWithConvertToBase64(byte[] inputBytes, string targetFile)
    {
        string fileString = Convert.ToBase64String(inputBytes);
                
        using (StreamWriter output = new StreamWriter(targetFile))
        {
            output.Write(fileString);
            output.Close();
        }
    }
    
    private static void EncodeWithCryptoClass(byte[] inputBytes, string targetFile)
    {
                            
        FileStream outputFileStream =
            new FileStream(targetFile, FileMode.Create, FileAccess.Write);
    
        // Create a new ToBase64Transform object to convert to base 64.
        ToBase64Transform base64Transform = new ToBase64Transform();
    
        // Create a new byte array with the size of the output block size.
        byte[] outputBytes = new byte[base64Transform.OutputBlockSize];
    
                
    
        // Verify that multiple blocks can not be transformed.
        if (!base64Transform.CanTransformMultipleBlocks)
        {
            // Initializie the offset size.
            int inputOffset = 0;
    
            // Iterate through inputBytes transforming by blockSize.
            int inputBlockSize = base64Transform.InputBlockSize;
    
            while (inputBytes.Length - inputOffset > inputBlockSize)
            {
                base64Transform.TransformBlock(
                    inputBytes,
                    inputOffset,
                    inputBytes.Length - inputOffset,
                    outputBytes,
                    0);
    
                inputOffset += base64Transform.InputBlockSize;
                outputFileStream.Write(
                    outputBytes,
                    0,
                    base64Transform.OutputBlockSize);
            }
    
            // Transform the final block of data.
            outputBytes = base64Transform.TransformFinalBlock(
                inputBytes,
                inputOffset,
                inputBytes.Length - inputOffset);
    
            outputFileStream.Write(outputBytes, 0, outputBytes.Length);
                    
        }
    
        // Determine if the current transform can be reused.
        if (!base64Transform.CanReuseTransform)
        {
            // Free up any used resources.
            base64Transform.Clear();
        }
    
        // Close file streams.
                
        outputFileStream.Close();
    }
