            Driver[] predictions = new Driver[6];
            predictions[0] = new Driver(10, "Michael Schumacher");
            predictions[1] = new Driver(10, "Michael Schumacher");
            predictions[2] = new Driver(9, "Fernando Alonso");
            predictions[3] = new Driver(8, "Jensen Button");
            predictions[4] = new Driver(7, "Felipe Massa");
            predictions[5] = new Driver(6, "Giancarlo Fisichella");
            var ds = predictions.Select((driver, i) => new { Name = driver.Name, Index = i })
                                .GroupBy(a => a.Name, a => a.Index);
