            StringBuilder sb = new StringBuilder();
            //start the calendar item
            sb.AppendLine("BEGIN:VCALENDAR");
            sb.AppendLine("VERSION:2.0");
            sb.AppendLine("PRODID:propertyqueen.com");
            sb.AppendLine("CALSCALE:GREGORIAN");
            sb.AppendLine("METHOD:PUBLISH");
            //create a time zone if needed, TZID to be used in the event itself
            sb.AppendLine("BEGIN:VTIMEZONE");
            sb.AppendLine("BEGIN:STANDARD");
            sb.AppendLine("TZID:Australia/Sydney");
            sb.AppendLine("TZOFFSETTO:+1000");
            sb.AppendLine("TZOFFSETFROM:+1000");
            sb.AppendLine("END:STANDARD");
            sb.AppendLine("END:VTIMEZONE");
            //add the event
            sb.AppendLine("BEGIN:VEVENT");
            //without timezones
            sb.AppendLine("DTSTART:" + EventStartDateTime.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("DTEND:" + EventEndDateTime.ToString("yyyyMMddTHHmm00"));
            sb.AppendLine("SUMMARY:" + Summary + "");
            sb.AppendLine("LOCATION:" + Location + "");
            sb.AppendLine("DESCRIPTION:" + Description + "");
            sb.AppendLine("PRIORITY:3");
            sb.AppendLine("END:VEVENT");
            sb.AppendLine("END:VCALENDAR");
            //send the calendar item to the browser
            Response.ClearHeaders();
            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "text/calendar";
            Response.AddHeader("content-length", sb.Length.ToString());
            Response.AddHeader("content-disposition", "attachment;filename=" + FileName);
            Response.Write(sb.ToString());
            Response.Flush();
            Response.End();
            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return File(bytes, "text/calendar", FileName); 
