            if (Time(b.Text) > Time(a.Text))
            {
                long q;
                q = (Time(b.Text) - Time(a.Text)) / TimeSpan.TicksPerMinute;
                c.Text = TimeSpan.FromMinutes(q).ToString();
            }
            if (Time(b.Text) < Time(a.Text))
            {
                long q;
                q = ((Time(b.Text)+24*TimeSpan.TicksPerHour) - Time(a.Text)) / 
                     TimeSpan.TicksPerMinute;
                c.Text = TimeSpan.FromMinutes(q).ToString();
            }
            if (Time(b.Text) == Time(a.Text))
                c.Text = "00:00";
        }
