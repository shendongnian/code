        private void myCalendar1_RightClick(object sender, MouseEventArgs e) {
            var hit = myCalendar1.HitTest(e.Location);
            if (hit.HitArea == MonthCalendar.HitArea.Date) {
                var dt = hit.Time;
                MessageBox.Show(dt.ToString());   // Display your context menu here
            }
        }
