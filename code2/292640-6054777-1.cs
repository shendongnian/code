    catch (SmtpFailedRecipientException se)
    {
      using (var errorfile = System.IO.File.CreateText("error-" + DateTime.Now.Ticks + ".txt"))
      {
        errorfile.WriteLine(se.StackTrace);  
        // variable se is already the right type, so no need to cast it      
        errorfile.WriteLine(se.FailedRecipient);       
        errorfile.WriteLine(se.ToString());
      }
    }
    catch (Exception e)
    {
      wl("Meldingen kunne ikke sendes til en eller flere mottakere.", ConsoleColor.Red);
      wl(e.Message, ConsoleColor.DarkRed);   
      // for other error types just write the info without the FailedRecipient
      using (var errorfile = System.IO.File.CreateText("error-" + DateTime.Now.Ticks + ".txt"))
      {
        errorfile.WriteLine(e.StackTrace);        
        errorfile.WriteLine(e.ToString());
      }
   
    }
