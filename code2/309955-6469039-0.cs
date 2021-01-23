        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        foreach (StatisticsData item in StatisticsCollection)
        {
            sb.AppendLine(item.ToString());
        }
