        private long startTimeTicks;
        public void init()
        {
            var mapper = Mappers.Xy<ValueRandomizerForTest>().X(model => 
             model.DateTime.Ticks).Y(model => model.Valuefordate);
            Charting.For<ValueRandomizerForTest>(mapper);
            ChartValues = new ChartValues<ValueRandomizerForTest>();
            DateTimeFormatter = value => new 
                 DateTime((long)value).ToString("ss");
            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            AxisUnit = TimeSpan.TicksPerSecond;
            var currentTime = DateTime.Now;
            startTimeTicks = currentTime.Ticks; // store start time
            SetAxisLimits(currentTime);
        }
        public void read()
        {
            var r = new Random();
            while (isreading)
            {
                Thread.Sleep(550);
                var now = DateTime.Now;
                var test = now.Second;
                _trend = r.Next(1, 100);
                if(ChartValues.Count == 0)
                {
                }
                ChartValues.Add(new ValueRandomizerForTest
                {
                    DateTime = now - new TimeSpan(startTimeTicks),
                    Valuefordate = _trend
                });
                SetAxisLimits(now);
                //lets only use the last 150 values
                if (ChartValues.Count > 150)
                {
                    ChartValues.RemoveAt(0);
                }
            }
        }
    
        public void SetAxisLimits(DateTime now)
        {
            long offsetTicks = now.Ticks - startTimeTicks; // compute offset ticks from program start (at call from init() this calculation will be equal to 0)
            AxisMin = Math.Max(offsetTicks - TimeSpan.FromSeconds(5).Ticks, 0);
            AxisMax = AxisMin  + TimeSpan.FromSeconds(6).Ticks; // Set max according to min
        }
