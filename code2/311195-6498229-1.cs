            foreach (Range c in Target.Cells)
            {
                string changedCell = c.get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);  
                MessageBox.Show("Address:" + changedCell + " Value: " + c.Value2);
            }
