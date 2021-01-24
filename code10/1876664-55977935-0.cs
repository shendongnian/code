        PropertyInfo[] pi = newRow.GetType().GetProperties();
        int propLoop = pi.Length;
        for (int a = 3; a < propLoop-2; a++)
        {
            double thisvalue = 0;
            double.TryParse(worksheet.Cells[a - 1, b].RichText.Text, out thisvalue);
            newRow.GetType().GetProperty(pi[a].Name).SetValue(newRow, thisvalue);
        }
