        var _url = "https://gw.sam.gov/SAMWS/1.0/Entity";
        //Run date is a specific date if provided otherwise use yesterday
        DateTime startDateTime = DateTime.Now.AddDays(-1).Date;
        for (int hr = 0; hr < 24; hr++)
        {
            XMLclassRequest xmlSoap = new XMLclassRequest();
            string soap = xmlSoap.BuildSOAPrequest(startDateTime.AddHours(hr));
            //string soap2 = xmlSoap.BuildSOAPrequest2(startDateTime.AddHours(hr));
            string response = null;   //This is the original pull with FAR and DFAR Responses
            //string response2 = null;  //This is FAR and DFAR
            
            using (MyWebClient client = new MyWebClient())
            {
                client.Headers.Add("Content-Type", "text/xml;charset=utf-8");
                client.Headers.Add("SOAPAction", "\"http://tempuri.org/IMyService/MyOperation\"");
                try
                {
                    response = client.UploadString(_url, soap);
                    //response2 = client.UploadString(_url, soap2);
                }
                catch
                { } //This will skip the hour attempted and move to next. The error I have been receiving is no data which is differently formatted XML that causes the error
            }
            //File.WriteAllText(@"D:\temp\far20190604.xml", response);
            XDocument xdoc = XDocument.Parse(response);
            var entities = from e in xdoc.Descendants("entity") select e;
            foreach (var e in entities)
            { 
                string DUNS = e.Descendants("DUNS").FirstOrDefault().Value;
                var provisions = from p in e.Descendants("provision") select p;
                foreach (var p in provisions)
                {
                    string ParentID = p.Descendants("id").FirstOrDefault().Value;
                    var answers = from a in p.Descendants("answer") select a;
                    foreach (var a in answers)
                    {
                        var section = a.Descendants("section").Count()>0?  a.Descendants("section").FirstOrDefault().Value : "";
                        var answerText = a.Descendants("answerText").Count() > 0 ? a.Descendants("answerText").FirstOrDefault().Value : "";
                        Console.WriteLine(DUNS + " " + ParentID + " " + section + " " + answerText);
                    }
                }
            }
