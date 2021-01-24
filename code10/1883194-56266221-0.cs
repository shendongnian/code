     var option = new ParallelOptions() {
      MaxDegreeOfParallelism = Convert.ToInt32(numThreads.Value)
     };
    
     Parallel.For(0, Global.MyList.Count, option, i=> {
      Debug.WriteLine("Start signal from thread", i.ToString());
       var account = Global.MyList[i];
       Thread.Sleep(5000);
       Debug.WriteLine("End signal from thread", i.ToString());  
     });
