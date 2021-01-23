    catch (Exception ex)
    {
    try
    {
       string recfilepath = "...
       string rectoadd = "RecDateTime=" + DateTime.Now.ToString()+ ...+ex.Message.ToString();
       File.AppendAllText(recfilepath, rectoadd);
    }
    catch ()
    {
    // do Event logging
    //also moving the string rectoadd declaration outside the try catch scope
    // will give u ability to use it in this catch block to write it to the windows event log
    }
    }
