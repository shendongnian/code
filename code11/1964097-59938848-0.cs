    public class Result
        {
            public string sys_id { get; set; }
        }
        public class RootObject
        {
            public List<Result> result { get; set; }
        }
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    
                    var res = new StreamReader(response.GetResponseStream()).ReadToEnd();
                    RootObject datalist = JsonConvert.DeserializeObject<RootObject>(res);
                    if (datalist.result != null && datalist.result.Count > 0)
                    {
                        var data = datalist.result[0];
                        UserSysID = "";
                        UserSysID = data.sys_id;
                        return data.sys_id;
                    }
                    return null;
                }
            }
