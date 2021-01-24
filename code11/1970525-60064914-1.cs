    //School Year changes in March until next March
    int month = DateTime.Now.Month;
    if (month >= 3)//from March to December it will be {current year}-{next year}
    {
        int yearBegin = DateTime.Now.Year;
    }
    else //January and February will be {last year}-{current year}
    {
        int yearBegin = DateTime.Now.Year - 1;
    }
    int yearEnd = yearBegin + 1;
    SchoolYear.Text = "S.Y." + yearBegin + "-" + yearEnd;
