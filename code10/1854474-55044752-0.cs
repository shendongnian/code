    foreach (var item in dataMsgTypes)
        {
            values.Add(item.Amount);
            Lables.Add(item.MsgType);
        }
        MsgTypeDoughnut = new SeriesCollection
        {
            new PieSeries
            {
                Title = "Amount",
                Values = values,
                DataLabels = true
            }
        };
