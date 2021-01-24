    protected void Button1_Click(object sender, EventArgs e)
    {
        //If today is 31 March 2019, filename = 20190301. If second person 
        //submit on same day, filename = 20190302
        //But if date is 1 April 2019, filename  = 20190401
    
        DateTime processDate = DateTime.Now; // get current date
        string caseNo = "";
        string casePrefix = string.Format("{0}{1:D2}", processDate.Year, processDate.Month); // to help you search previous cases and create the new caseNo
        Int16 caseInMonthNumber = 0; // Int value of the case so you can increment
        string sqlResult = ""; // result from your query
        string sqlString = string.Format("SELECT caseNo from TABLE WHERE caseNo LIKE '{0}%' ORDER BY caseNo DESC LIMIT 1", casePrefix); // syntax might change depending on your DB
    
    
        // Function to call your database or whatever you are using to keep count of cases,  this will get you the highest value so the highest case... return the caeNo value
        // sqlResult = functionQueryToDB(sqlString); // or just send the prefix and create the 'sqlString' string in the function       
    
        //process the result from the database if there are no results, you don't need to do anything extra, start with caseInMonthNumber = 1,
        //but if you get a result, you need to read the last part of the string and increment by one... Depending on the logic for your program you might want to add
        // extra validations for the string
        if ( sqlResult != "" ) {
            if ( !Int16.TryParse(sqlResult.Substring(sqlResult.Length - 2) , out caseInMonthNumber) ) {
                //error handling, the last two digits are not a valid number
                return;
            }
        }
    
        caseNo = string.Format("{0}{1:D2}", casePrefix, ++caseInMonthNumber);
    
        // Do what you need with the new caseNo
    }
