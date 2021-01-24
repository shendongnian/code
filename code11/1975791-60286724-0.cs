    string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    string docPath = path + "\\" + "AleksReport.csv";
    using (StreamWriter writer = new StreamWriter(docPath)) {
        while (!s.Contains("No records found")) //When API returns "No Records Found" we know we've reached the last page of data we need to get.
        {
            rpcURL = "https://api.WEBSITEcom/urlrpc?method=getPlacementReport&username=" + userName + "&password=" + passWord + "&class_code=" + classCode + "&from_date=" + startDate + "&to_date=" + endDate + "&page_num=" + page;
            Console.WriteLine(rpcURL);
            client.Headers.Add("user-agent", "Mozilla/4.0 (Compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
            using (var stream = client.OpenRead(rpcURL))
            using (var sr = new StreamReader(stream))
            {
                s = sr.ReadToEnd();
        
                Console.WriteLine(s);
        
                if (!s.Contains("No records found"))
                {
                    writer.WriteLine(s);
                }
                else
                {
                    Console.WriteLine("End of records");
                }
            }
            page++;
        }
    }
