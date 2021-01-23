try
{
    using (WebResponse myResponse = request.GetResponse())
      // do stuff
}
catch (WebException webEx)
{
    webEx.Response.Close();
}
