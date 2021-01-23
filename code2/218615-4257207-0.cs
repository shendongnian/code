         Stopwatch sw = new Stopwatch();
         const int NUM_ITEMS = 10000;
         const int NUM_LOOPS2 = 1000000000;
         List<int> lst = new List<int>(NUM_ITEMS);
         IList<int> ilst = lst;
         for (int i = 0; i < NUM_ITEMS; i++)
         {
            lst.Add(i);
         }
         int count = 0;
         sw.Reset();
         //GC.Collect();
         sw.Start();
         for (int i = 0; i < NUM_LOOPS2; i++)
         {
            count = lst.Count;
         }
         sw.Stop();
         Console.Out.WriteLine("Took " + (sw.ElapsedMilliseconds) + "ms - 1.");
         sw.Reset();
         //GC.Collect();
         sw.Start();
         for (int i = 0; i < NUM_LOOPS2; i++)
         {
            count = ilst.Count;
         }
         sw.Stop();
         Console.Out.WriteLine("Took " + (sw.ElapsedMilliseconds) + "ms - 2.");
      }
