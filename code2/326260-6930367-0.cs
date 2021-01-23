    IList<DateTime> listx = new List<DateTime>();
    IList<double> listy = new List<double>();
    
    //iterate and add your values to the two lists: listx and listy
    
    //when you're done, bind the lists to the points collection
    chart1.Series[i / 3].Points.DataBindXY(listx, listy);
