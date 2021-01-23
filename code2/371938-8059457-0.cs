        Button[] btnMonday = new Button[20];
        string[] timeslot = { "08:00 AM", "08:30 AM", "09:00 AM", "09:30 AM", "10:00 AM", "10:30 AM", "11:00 AM", "11:30 AM", "12:00 PM", "12:30 PM", "01:00 PM", "01:30 PM", "02:00 PM", "02:30 PM", "03:00 PM", "03:30 PM", "04:00 PM", "04:30 PM", "05:00 PM", "05:30 PM" };
        #region Monday
        for (int i = 0; i < 20; i++)
        {
            btnMonday[i] = new Button();
            btnMonday[i].Height = 38;
            btnMonday[i].Width = 256;
            btnMonday[i].Content = timeslot[i];
            // Sets dependency properties
            Grid.SetColumn(btnMonday[i], 0);
            Grid.SetRow(btnMonday[i], i + 1);
            // Adds the dynamically created control to the canvas
            LayoutRoot.Children.Add(btnMonday[i]);
        }
