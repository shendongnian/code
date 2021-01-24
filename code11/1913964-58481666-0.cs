    public void NumericalAxis_ActualRangeChanged(object sender,ActualRangeChangedEventArgs e){
    
    SalesViewModel p = (sender as Axis).BindingContext as SalesViewModel;   
    if(p != null )
    {		            
      e.ActualMinimum = p.AxisMinimum;
    }}
