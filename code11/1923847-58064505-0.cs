private static void Rescale(ushort[,] originalImg, byte[,] scaledImg, in (ushort, ushort) limits)
{
  Debug.Assert(originalImg != null);
  Debug.Assert(originalImg.Length != 0);
  Debug.Assert(scaledImg != null);
  Debug.Assert(scaledImg.Length == originalImg.Length);
  ushort min = limits.Item1;
  ushort max = limits.Item2;
  int width = originalImg.GetLength(1);
  int height = originalImg.GetLength(0);
  Parallel.For(0, height, row =>
  {
    for (var col = 0; col < width; ++col)
    {
      ushort value = originalImg[row, col];
      if (value < min)
        scaledImg[row, col] = 0;
      else if (value > max)
        scaledImg[row, col] = 255;
      else
        scaledImg[row, col] = (byte)(255.0 * (value - min) / (max - min));
    }
  });
}
This is just one step and some others are much more complex but the approach would be similar.
Some of the things mentioned like SIMD/AVX or the answer of user3666197 unfortunately are well beyond my abilities right now so I couldn't test that out.
It's still relatively easy to put enough processing load into the stream to tank the frame rate but for my application the performance should be enough now. Thanks to everyone who provided input, I'll mark Dai's answer as accepted because I found it the most helpful.
