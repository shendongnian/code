    static void Main( string[] args )
    {
      const int ITERATION_NUMBER = 100;
      TimeSpan[] normal = new TimeSpan[ITERATION_NUMBER];
      TimeSpan[] ilp = new TimeSpan[ITERATION_NUMBER];
      int SIZE = 4000000;
      float[] data = new float[SIZE];
      float safe = 0.0f;
      //Normal for
      Stopwatch sw = new Stopwatch();
      for (int iteration = 0; iteration < ITERATION_NUMBER; iteration++)
      {
        //Initialization
        for (int i = 0; i < data.Length; i++)
        {
          data[i] = 1.0f;
        }
        sw.Start();
        for (int index = 0; index < data.Length; index++)
        {
          data[index] /= 3.0f * data[index] > 2.0f / data[index] ? 2.0f / data[index] : 3.0f * data[index];
        }
        sw.Stop();
        normal[iteration] = sw.Elapsed;
        safe = data[0];
        //Initialization
        for (int i = 0; i < data.Length; i++)
        {
          data[i] = 1.0f;
        }
        sw.Reset();
        //ILP For
        sw.Start();
        float ac1, ac2, ac3, ac4;
        int length = data.Length / 4;
        for (int i = 0; i < length; i++)
        {
          int index0 = i << 2;
          int index1 = index0;
          int index2 = index0 + 1;
          int index3 = index0 + 2;
          int index4 = index0 + 3;
          ac1 = 3.0f * data[index1] > 2.0f / data[index1] ? 2.0f / data[index1] : 3.0f * data[index1];
          ac2 = 3.0f * data[index2] > 2.0f / data[index2] ? 2.0f / data[index2] : 3.0f * data[index2];
          ac3 = 3.0f * data[index3] > 2.0f / data[index3] ? 2.0f / data[index3] : 3.0f * data[index3];
          ac4 = 3.0f * data[index4] > 2.0f / data[index4] ? 2.0f / data[index4] : 3.0f * data[index4];
          data[index1] /= ac1;
          data[index2] /= ac2;
          data[index3] /= ac3;
          data[index4] /= ac4;
        }
        sw.Stop();
        ilp[iteration] = sw.Elapsed;
        sw.Reset();
      }
      Console.WriteLine(data.All(item => item == data[0]));
      Console.WriteLine(data[0] == safe);
      Console.WriteLine();
      double normalElapsed = normal.Max(time => time.TotalMilliseconds);
      Console.WriteLine(String.Format("Normal Max.: {0}", normalElapsed));
      double ilpElapsed = ilp.Max(time => time.TotalMilliseconds);
      Console.WriteLine(String.Format("ILP    Max.: {0}", ilpElapsed));
      Console.WriteLine();
      normalElapsed = normal.Average(time => time.TotalMilliseconds);
      Console.WriteLine(String.Format("Normal Avg.: {0}", normalElapsed));
      ilpElapsed = ilp.Average(time => time.TotalMilliseconds);
      Console.WriteLine(String.Format("ILP    Avg.: {0}", ilpElapsed));
      Console.WriteLine();
      normalElapsed = normal.Min(time => time.TotalMilliseconds);
      Console.WriteLine(String.Format("Normal Min.: {0}", normalElapsed));
      ilpElapsed = ilp.Min(time => time.TotalMilliseconds);
      Console.WriteLine(String.Format("ILP    Min.: {0}", ilpElapsed));
    }
  
