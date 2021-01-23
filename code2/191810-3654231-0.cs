    Bitmap mask = ...;
    Bitmap input = ...;
    
    Bitmap output = new Bitmap(input.Width, input.Height, PixelFormat.Format32bppArgb);
    var rect = new Rectangle(0, 0, input.Width, input.Height);
    var bitsMask = mask.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    var bitsInput = input.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
    var bitsOutput = output.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
    unsafe
    {
        for (int y = 0; y < input.Height; y++)
        {
            byte* ptrMask = (byte*) bitsMask.Scan0 + y * bitsMask.Stride;
            byte* ptrInput = (byte*) bitsInput.Scan0 + y * bitsInput.Stride;
            byte* ptrOutput = (byte*) bitsOutput.Scan0 + y * bitsOutput.Stride;
            for (int x = 0; x < input.Width; x++)
            {
                ptrOutput[4 * x] = ptrInput[4 * x];           // blue
                ptrOutput[4 * x + 1] = ptrInput[4 * x + 1];   // green
                ptrOutput[4 * x + 2] = ptrInput[4 * x + 2];   // red
                ptrOutput[4 * x + 3] = ptrMask[4 * x];        // alpha
            }
        }
    }
    mask.UnlockBits(bitsMask);
    input.UnlockBits(bitsInput);
    output.UnlockBits(bitsOutput);
    output.Save(...);
