    catch (WebException webex)
    {
    Console.WriteLine("Unable to perform command: " + req);
    
    String data = String.Empty;
    if (webex.Response != null)
    {
       StreamReader r = new StreamReader(webex.Response.GetResponseStream());
       data = r.ReadToEnd(); 
       r.Close();
    }
    Console.WriteLine(webex.Message);
    Console.WriteLine(data);
