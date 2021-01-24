    // These will make the if statement useless, it will never hit else
    // string Subject_Code = "";
    // string Subject_Name = "";
    
    //Assumptions: Subject_Codes contians these props
    if(string.IsNullOrEmtpy(SubjectCodes.Subject_Code) && string.IsNullOrEmpty(SubjectCodes.Subject_Name)){
          // whatever you want to do...
    } else {
          //sql here - I'll skip the comments on why your sql is bad - re: use parameters
          // return after successful sql - look into a try/catch
    }
