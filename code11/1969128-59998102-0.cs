    public static DataTable selectAllCodeInfo()
    {
        DataTable dt = new DataTable();
        try
        {
             var httpWebRequest = (HttpWebRequest)WebRequest.Create(API_ADDRESS + "/api/codeInfo");
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "GET";
                if (!string.IsNullOrEmpty(RequestParameters))
                    using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                    {
                        streamWriter.Write(RequestParameters);
                    }
                var result = string.Empty;
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    result = streamReader.ReadToEnd();
                }
            dt = JsonConvert.DeserializeObject<DataTable>(result.list) 
              
        } catch(WebException)
        {
            //API 서버 닫혀있을때, 연결이 안될때
            Console.Write("예외");
            return null;
        }
        catch (Exception)
        {
            //그 외의 Exception
            Console.Write("예외");
            return null;
        }
        return dt;
    }
