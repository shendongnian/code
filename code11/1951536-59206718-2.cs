    Observable.Interval(TimeSpan.FromMinute(2), DispatcherScheduler.Current)
         .Subscribe(
            x =>
            {
              string txt = Convert.ToString(TotCostLong);
              File.WriteAllText("total-cost.txt", txt);
            });
