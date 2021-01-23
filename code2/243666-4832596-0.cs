    if (extTime1.timeZone == "CDT")
    {
       // Try this
       string text = cboTimeZone.SelectedItem.ToString(); // don't forget the parenthesis
       MessageBox.Show(text, "Debug");
       // Then this
       text = cboTimeZone.Text;
       MessageBox.Show(text, "Debug");
       // then (as a safeguard)
       if (String.IsNullOrEmpty(text))
       {
           return;
       }
       switch (text)
       {
          case "EST":
          time1.Hour = time1.Hour + 1; /* CDT hours + 1 to get EST */
          extTime1.Hour = extTime1.Hour + 1;
          break;
          case "MST":
          time1.Hour = time1.Hour - 1; /* CDT hours - 1 to get MST */
          break;
          case "PST":
          time1.Hour = time1.Hour - 2; /* CDT hours - 2 to get PST */
          break;
    
          default: /* CDT is the default time zone*/
          break;
      }
    }
