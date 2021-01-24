     private void baslangicDateTimePicker_ValueChanged(object sender, EventArgs e)
            {
                if (baslangicDateTimePicker.Value.ToShortTimeString() == "18:00")
                {
                    DateTime temp = baslangicDateTimePicker.Value.AddDays(1);
                    if (temp >= baslangicDateTimePicker.MaxDate.Date)
                        baslangicDateTimePicker.Value.AddHours(-1);
                    else
                        baslangicDateTimePicker.Value = temp.AddHours(-9);
                }
                if (baslangicDateTimePicker.Value.ToShortTimeString() == "08:00")
                {
                    DateTime temp = baslangicDateTimePicker.Value.AddDays(-1);
                    if (temp <= baslangicDateTimePicker.MinDate.Date)
                        baslangicDateTimePicker.Value.AddHours(1);
                    else
                        baslangicDateTimePicker.Value = temp.AddHours(9);
                }
            }
