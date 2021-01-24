    MsgTypeDoughnut = new SeriesCollection();
    foreach (var item in dataMsgTypes)
            {
                MsgTypeDoughnut.Add(new PieSeries
                {
                    Title = "test",
                    Values = new ChartValues<ObservableValue> { new ObservableValue(item.Amount) },
                    DataLabels = true,
                    Stroke = System.Windows.Media.Brushes.Transparent
                });
                Lables.Add("MsgType " + (item.MsgType));
            }
