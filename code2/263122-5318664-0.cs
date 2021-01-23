        // converting enums to strings is easy    
        String WhatDayItIs = DayOfWeek.Monday.ToString();     
 
        // converting strings to enums is a bit more work    
        DayOfWeek WhatDayItIsDOW;
 
        if (Enum.IsDefined(typeof(DayOfWeek), WhatDayItIs)) 
            WhatDayItIsDOW = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), 
