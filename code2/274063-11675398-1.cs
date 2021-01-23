    public string GetLocation(string IP)
    {
        var location = "";
        List<string> HTML_code = new List<string>();
        WebRequest request = WebRequest.Create("http://www.maxmind.com/app/locate_demo_ip?ips=" + IP);
        using (WebResponse response = request.GetResponse())
        using (StreamReader stream = new StreamReader(response.GetResponseStream()))
        {
            string line;
            while ((line = stream.ReadLine()) != null)
            {
                HTML_code.Add(line);
            }
        }
        location = (HTML_code[296].Replace("<td><font size=\"-1\">", "")).Replace("</font></td>", ""); 
        return location;
    }
