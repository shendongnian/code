    var intervalList = new List<Tuple<string, timer, delegate>>() { 
      new Tuple<string, timer, delegate> { "Interval1", m_sentTransactionTimer, Foo1 },  
      new Tuple<string, timer, delegate>  { "Interval2" m_checkStatusTimer, Foo2 }, 
      new Tuple<string, timer, delegate> { "Interval3", m_adaptorsTimer , Foo3 }  
    }
    intervalList.ForEach(tuple => {
      var interval = Convert.ToDouble(System.Configuration.ConfigurationManager.AppSettings[tuple.Item1])
      tuple.Item2.Interval = interval;
      tuple.Item2.Elapsed += tuple.Item3;
      tuple.Item2.Start();
    });    
