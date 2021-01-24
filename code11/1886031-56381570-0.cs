     var typesOutput = new StringBuilder();
     ...
     //typesOutput += newLine + DateTimeFormatInfo.CurrentInfo.GetMonthName(m) + newLine;
     typesOutput.AppendLine();
     typesOutput.AppendLine(DateTimeFormatInfo.CurrentInfo.GetMonthName(m));
     ...
     //typesOutput += "Type of appointment scheduled: " + t.Returned + "   " + "-Appointments of this type: " + t.Tally + newLine;
     typesOutput.AppendFormat("Type of appointment scheduled: {0} - Appointments of this type:  {1}\n", t.Returned, t.Tally);
     ...
     ReportsTextBox.Text = typesOutput.ToString();
