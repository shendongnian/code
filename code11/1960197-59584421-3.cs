    private async Task SetUpTimer(string alertTime, string sound, int duration)
        {
            MessageBox.Show("Made it"); //For Testing
            var time = alertTime;
            var timeParts = time.Split(new char[1] { ':' });
            var dateNow = DateTime.Now;
            var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                       int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
            TimeSpan t;
            if (date > dateNow)
                t = date - dateNow;
            else
            {
                return;
            }
            await Task.Delay(t);
            Bell(sound, duration)
            MessageBox.Show("Done"); //For Testing
        }
