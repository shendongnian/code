    protected void Button2_Click(object sender, EventArgs e)
    {
        var fb = new FacebookClient("your token here");
        var query = string.Format(@"SELECT status_id,message,time,source,uid,place_id
                                    FROM status WHERE uid IN (SELECT uid FROM status WHERE uid = 'Your FB ID here') ORDER BY time DESC");
        dynamic parameters = new ExpandoObject();
        parameters.q = query;
        dynamic results = fb.Get("/fql", parameters);
        List<MyPost> q = JsonConvert.DeserializeObject<List<MyPost>>(results.data.ToString());
        GridView2.DataSource = q;
        GridView2.DataBind();
    }
     public class MyPost
    {
        public long status_id { get; set; }
        public string message { get; set; }
        public string time { get; set; }
        public string source { get; set; }
        public long uid { get; set; }
        public string place_id { get; set; }
       
    }
