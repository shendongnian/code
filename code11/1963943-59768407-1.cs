    Holiday MyStatus = (Holiday)Enum.Parse(typeof(Holiday), CmbTypeHolidays.Text, true);
            var holid = new AbstractTest(CmbEmpHolidays.Text.Split('-')[0], CmbEmpHolidays.Text.Split('-')[1], MyStatus, Convert.ToDateTime(StartDateHolidays.Value), Convert.ToDateTime(EndDateHolidays.Value));
            
            if (!holid.HolidayValidation(MyStatus))
            {
                holiday.Add(holid);
                var bindingList = new BindingList<AbstractTest>(holiday);
                dataGridHolidays.DataSource = bindingList;
                controlPanelHolidays.Visible = false;
            }
            else
            {
                MessageBox.Show($"{holid.TypeOfHoliday} Cant be more than {(int)MyStatus} Days");
            }
