    double* dp0;
    float* fp0;
    
    fixed (double* dp1 = dbl)
    {
        dp0 = dp1;
        float[] newFlt = new float[count];
        fixed (float* fp1 = newFlt)
        {
            fp0 = fp1;
            for (int i = 0; i < numCh; i++)
            {
                //Parallel.For(0, count, (j) =>
                for (int j = 0; j < count; j++)
                {
                    fp0[j] = (float)dp0[i * count + j];
                }
                //});
                flt[i] = newFlt.Clone() as float[];
            }
         }
      }
