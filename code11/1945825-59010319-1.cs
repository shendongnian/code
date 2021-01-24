    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            // the hidden value will be used to uniquely name the cookie and
            // will be used both on the server and the client side to
            // work with the cookie.
            windowid.Value = Guid.NewGuid().ToString();
        }
    }
    
    
    public void GetCsv()
    {
        // ...    
        var bytes = Encoding.ASCII.GetBytes(sb.ToString());
    
        Response.Clear();
        Response.Cookies.Add(new HttpCookie(windowid.Value, DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss:ff")));
        Response.AddHeader("Content-Disposition", "attachment; filename=contacts.csv");
        Response.AddHeader("Content-Length", bytes.Length.ToString());
        Response.ContentType = "text/csv";
        Response.Write(sb.ToString());
        Response.Flush();
        Response.End();
    }
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        // for demo purposes only
        System.Threading.Thread.Sleep(2000);    
        GetCsv();
    }
