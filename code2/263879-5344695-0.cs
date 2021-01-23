            private void CreateGraphic(ZedGraphControl zgc)
        {
            // référence vers le "canevas"
            GraphPane pane = zgc.GraphPane;
            pane.Title.Text = "Japanese Candlestick Chart Demo";
            pane.XAxis.Title.Text = "Trading Date";
            pane.YAxis.Title.Text = "Share Price, $US";
            FileHelperEngine<MetaTrader4> engine = new FileHelperEngine<MetaTrader4>();
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
            MetaTrader4[] res = engine.ReadFile(@"..\..\Data\EURUSD240.csv");
            if (engine.ErrorManager.ErrorCount > 0)
                engine.ErrorManager.SaveErrors("Errors.txt");
            StockPointList spl = new StockPointList();
            foreach (MetaTrader4 quotes in res)
            {
                DateTime dateTime = new DateTime();
                dateTime = DateTime.ParseExact(quotes.Date + "-" + quotes.Time, "yyyy.MM.dd-HH:mm",
                                                 null);
                XDate xDate = new XDate(dateTime);
                StockPt pt = new StockPt(xDate, quotes.Hight, quotes.Low, quotes.Open, quotes.Close, quotes.Volume);
                spl.Add(pt);
            }
            JapaneseCandleStickItem myCurve = pane.AddJapaneseCandleStick("trades", spl);
            myCurve.Stick.IsAutoSize = true;
            myCurve.Stick.Color = Color.Blue;
            // Use DateAsOrdinal to skip weekend gaps
            pane.XAxis.Type = AxisType.DateAsOrdinal;
            // pretty it up a little
            pane.Chart.Fill = new Fill(Color.White, Color.LightGoldenrodYellow, 45.0f);
            pane.Fill = new Fill(Color.White, Color.FromArgb(220, 220, 255), 45.0f);
            zgc.AxisChange();
        }
