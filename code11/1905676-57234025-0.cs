        var today = DateTime.Now;
        var dd = today.Date.Day;
        var mm = today.Month + 1;
        var yyyy = today.Year;
        var yyyy_string = yyyy.ToString();
        var mm_string = mm.ToString();
        var dd_string = dd.ToString();
        if (dd < 10)
        {
            dd_string = '0' + dd_string;
        }
        if (mm < 10)
        {
            mm_string = '0' + mm_string;
        }
        var today_string = yyyy_string + '-' + mm_string + '-' + 
        dd_string;
