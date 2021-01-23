    private string DateFormat
    {
        get { return "yyyyMMddTHHmmssZ"; } // 20060215T092000Z
    }
    
    public void ProcessRequest(HttpContext context)
    {
        DateTime startDate = DateTime.Now.AddDays(5);
        DateTime endDate = startDate.AddMinutes(35);
        string organizer = "foo@bar.com";
        string location = "My House";
        string summary = "My Event";
        string description = "Please come to\\nMy House";
        
        context.Response.ContentType="text/calendar";
        context.Response.AddHeader("Content-disposition", "attachment; filename=appointment.ics");
        
        context.Response.Write("BEGIN:VCALENDAR");
        context.Response.Write("\nVERSION:2.0");
        context.Response.Write("\nMETHOD:PUBLISH");
        context.Response.Write("\nBEGIN:VEVENT");
        context.Response.Write("\nORGANIZER:MAILTO:" + organizer);
        context.Response.Write("\nDTSTART:" + startDate.ToUniversalTime().ToString(DateFormat));
        context.Response.Write("\nDTEND:" + endDate.ToUniversalTime().ToString(DateFormat));
        context.Response.Write("\nLOCATION:" + location);
        context.Response.Write("\nUID:" + DateTime.Now.ToUniversalTime().ToString(DateFormat) + "@mysite.com");
        context.Response.Write("\nDTSTAMP:" + DateTime.Now.ToUniversalTime().ToString(DateFormat));
        context.Response.Write("\nSUMMARY:" + summary);
        context.Response.Write("\nDESCRIPTION:" + description);
        context.Response.Write("\nPRIORITY:5");
        context.Response.Write("\nCLASS:PUBLIC");
        context.Response.Write("\nEND:VEVENT");
        context.Response.Write("\nEND:VCALENDAR");
        context.Response.End();
    }
