        string lblweekoff = "Sun,Sat";
        string txtDate = "30/Mar/2019"; // you might need to format this date 
        var dayColumns = new[] { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
        var offDay = lblweekoff.Split(',').ToList();
        DateTime Date = Convert.ToDateTime(txtDate);
        if (offDay.Contains(Date.ToString("ddd")))// weekend
        {
            //some code
        }
        else
        {
            //some code
        }
