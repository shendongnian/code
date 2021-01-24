        public void NumericalAxis_ActualRangeChanged(object sender, ActualRangeChangedEventArgs e)
		        {
		            SalesViewModel p = new SalesViewModel();
		            e.ActualMinimum = p.AxisMinimum;
		         }
