        public class sample
        {
            public string val1;
            public string val2;
        }
    [WebMethod]
    public sample[] UpdateBold(int count, float lat, float lng)
    
    {
    
                DataTable dt = new Gallery().DisplayNearestByLatLong(count, lat, lng);
                var samples = new List<sample>();
    
                foreach(DataRow item in dt.Rows)
                {
                    var s = new sample();
                    s.val1 = item[0].ToString();
                    s.val2 = item[1].ToString();
                }
                return samples.ToArray();
    }
