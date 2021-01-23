       [MethodImpl(MethodImplOptions.Synchronized)]
       static void bg_ProgressChanged(object sender, ProgressChangedEventArgs e) {
         Console.WriteLine(e.ProgressPercentage);
         Thread.Sleep(100);
         Console.WriteLine(e.ProgressPercentage);
       }
