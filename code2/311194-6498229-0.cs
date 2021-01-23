            string changedCells = Target.get_Address(Missing.Value, Missing.Value, Excel.XlReferenceStyle.xlA1, Missing.Value, Missing.Value);
            Range r = sheet.get_Range(changedCells, Type.Missing);
            foreach (Range c in r.Cells)
            {
                string changedCell = c.get_Address(Type.Missing, Type.Missing, XlReferenceStyle.xlA1, Type.Missing, Type.Missing);  
                MessageBox.Show(changedCell);
            }
