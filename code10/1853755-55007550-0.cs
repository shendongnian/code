    if (combobox.SelectedValue is IConvertible)
            {
                int id = Convert.ToInt32(combobox.SelectedValue);
                string name = combobox.Text;
                // Or
                Student student = cmbCars.SelectedValue as Student;
                int idd = student.Id;
                string names = student.Name;
            }
