    Object lockOnMe = new Object();
    ... in your Add loop
    (int i = 0; i < dacPoints.Count; i += 1) { 
        TimeSpan span = new TimeSpan(0, 0, i + 1); 
        lock (lockOnMe) { 
            presenter.addPoint(span.ToString(), dacPoints[i]); 
        } 
        System.Threading.Thread.Sleep(200); 
    }
    ... when calling DataBindXY()
    lock (lockOnMe) {
        // Note that I copy the lists here.  
        // This is because calling DataBindXY is not necessarily a serial, 
        // blocking operation, and you don't want the UI thread touching 
        // these lists later on after we exit the lock
        chart.Series[0].Points.DataBindXY(xAxis.ToList(), yAxis.ToList());
    }
