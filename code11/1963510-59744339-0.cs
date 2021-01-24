          static float[] GetBitmapPixels(Bitmap bitmap)
        {
            var floatValues = new float[_inputSize * _inputSize * 3];
            using (var scaledBitmap = Bitmap.CreateScaledBitmap(bitmap, _inputSize, _inputSize, false))
            {
                using (var resizedBitmap = scaledBitmap.Copy(Bitmap.Config.Argb8888, false))
                {
                    var intValues = new int[_inputSize * _inputSize];
                    resizedBitmap.GetPixels(intValues, 0, resizedBitmap.Width, 0, 0, resizedBitmap.Width, resizedBitmap.Height);
                    for (int i = 0; i < intValues.Length; ++i)
                    {
                        var val = intValues[i];
                        floatValues[i * 3 + 0] = ((val & 0xFF) - 104);
                        floatValues[i * 3 + 1] = (((val >> 8) & 0xFF) - 117);
                        floatValues[i * 3 + 2] = (((val >> 16) & 0xFF) - 123);
                    }
                    resizedBitmap.Recycle();
                }
                scaledBitmap.Recycle();
            }
            return floatValues;
        }
