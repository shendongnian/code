            DateTime firstDate = new DateTime(2011, 6, 5);
            DateTime secondDate = new DateTime(2011, 6, 1);
            double weight1 = 0.4;
            double weight2 = 0.6;
            var averageTicks = (firstDate.Ticks * weight1) + (secondDate.Ticks * weight2) / 2;
            DateTime averageDate = new DateTime(Convert.ToInt64(averageTicks));
