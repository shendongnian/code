    string dateInput = txtStartDate.Text;
            DateTime dt = Convert.ToDateTime(dateInput);
            DayOfWeek today = dt.DayOfWeek;
    
            if (today != DayOfWeek.Monday)
            {
                MessageBox.Show("Day is not a monday");
            }
