 public void LogEntry(string msg, string path)
    {
        try
        {
            StreamWriter sw;
            // appending this text to the file
            sw = File.AppendText(path);
            // here we are writing a formatted string 
            sw.WriteLine(msg);
            // closing the stream writer
            sw.Close();
        }
        catch (Exception ex)
        {
            ex.GetBaseException();
        }
    }
In this function you have to pass the two parameter 
1. Message 
2. Path of your text File 
For Example 
string logmsg;
 logmsg = "** " + DateTime.Now.ToString().Trim() + "||" + "UserId:" + txtuser.Text.Trim() + "||" + " EventDesc: Login Attempt Failed";
                   l1.LogEntry(logmsg, Server.MapPath("LoginEvent.txt"));
here the 
LoginEvnet.txt is the name of the text file where i am storing the log details
logmsg-It is the message you have to track the or store in the log file 
