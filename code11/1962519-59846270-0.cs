public class Divergence5min : Strategy
{
 private ObservableCollection <double> LastLSwDMI;
....
 LastLSwDMI = new ObservableCollection <double>();
 
...
 private void LookAfterLastLow()
 {
   LastLSwDMI.CollectionChanged += (s, e) => 
   {
	 if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
	 {					
		if(/*!LSwDMIbool &&*/ listCountLL > 1 && BarsInProgress == 0 && IsFirstTickOfBar)
	    {		
		   lastBarL = LastLSwDMIbar[k-1] + n;
		   if (n <= 5)
		   {
			  newLastLowPrice = Lows[0].GetValueAt(lastBarL);
			  if (newLastLowPrice < LastLSwDMIprice[k-1])
			  {
				 LastLSwDMIprice[k-1] = newLastLowPrice;
				 newLastLowBar = lastBarL;
				 LastLSwDMIpriceBar[k-1] = newLastLowBar;
				 lowSwBarDiffB = Math.Abs(newLastLowBar - LastLSwDMIbar[k-1]);															
			  }
			  n++;
		    }				
	     }
      }
    };
  }
}
