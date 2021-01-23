    public JobQuote quote 
    { 
        get  
        { 
            if (ViewState["Quote"] != null) 
                return (JobQuote)ViewState["Quote"]; 
            else 
            { 
                // you only construct a new instance but you dont assign it to the viewstate
                JobQuote newQuote = new JobQuote(); 
                // add the following line to fix the problem
                // ViewState["Quote"] = newQuote;
                return newQuote; 
            }    
        } 
