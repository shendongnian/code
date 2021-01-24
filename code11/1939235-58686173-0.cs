			else if (State == State.Configure)
			{
				AddDataSeries(Data.BarsPeriodType.Minute, 1);
			}
		}
		protected override void OnBarUpdate()
		{
			
		if (BarsInProgress != 0) 
			return;
		if (CurrentBars[0] < 1)
			return;
		if (CurrentBars[0] <= BarsRequiredToPlot) return;
		
		Clostr = Close[0].ToString("0.########");
		 // Set 1
		if (CurrentBar % 2 == 0)
			{
				WriteFile(	
				
							"group {Gronam}" + Environment.NewLine +
							"symbol: {Symtic} started downtrend {Castyp} {Clostr}" + Environment.NewLine
							
							);
			}
		 // Set 2
		if (CurrentBar % 2 == 1)
			{
				WriteFile(	
							"group {Gronam}" + Environment.NewLine +
							"symbol: {Symtic} ended downtrend {Castyp} {Clostr}" + Environment.NewLine
							
							);
			}
		}
			
			private object lockObj = new object();
 
		private void WriteFile(string text)
		{
		  lock (lockObj)
		  {
