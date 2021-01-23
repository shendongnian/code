      public static NoiseReduction(this float[] src, int severity = 1)
        {
            for (int i = 1; i < src.Length; i++)
            {
                //---------------------------------------------------------------avg
                var start = (i - severity > 0 ? i - severity : 0);
                var end = (i + severity < src.Length ? i + severity : src.Length);
                float sum = 0;
                for (int j = start; j < end; j++)
                {
                    sum += src[j];
                }
                var avg = sum / (end - start);
                //---------------------------------------------------------------
                src[i] = avg;
            }
        }
