    List<double> first = bigList.Take(8).ToList();
    List<double> second = bigList.Skip(8).Take(8).ToList();
    List<double> third = bigList.Skip(16).Take(9).ToList();
    List<double> fourth = bigList.Skip(25).Take(10).ToList();
    List<double> fifth = bigList.Skip(35).Take(11).ToList();
    // The last one is without Take to get every remaining element
    List<double> sixth = bigList.Skip(46).ToList();
