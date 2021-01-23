            DataGridTextColumn colNameStatus2 = new DataGridTextColumn();
            colNameStatus2.Header = "Status";
            colNameStatus2.MinWidth = 100;
            colNameStatus2.Binding = new Binding("Status");
            grdComputer_Servives.Columns.Add(colNameStatus2);
            Style style = new Style(typeof(TextBlock));
            Trigger running = new Trigger() { Property = TextBlock.TextProperty, Value = "Running" };
            Trigger stopped = new Trigger() { Property = TextBlock.TextProperty, Value = "Stopped" };
            stopped.Setters.Add(new Setter() { Property = TextBlock.BackgroundProperty, Value = Brushes.Blue });
            running.Setters.Add(new Setter() { Property = TextBlock.BackgroundProperty, Value = Brushes.Green });
            style.Triggers.Add(running);
            style.Triggers.Add(stopped);
            colNameStatus2.ElementStyle = style;
            foreach (var Service in computerResult)
            {
                var RowName = Service;  
                grdComputer_Servives.Items.Add(RowName);
            }
