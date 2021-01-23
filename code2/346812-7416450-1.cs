    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    namespace WebApplication1
    {
        public partial class _Default : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!Page.IsPostBack)
                {
                    List<Match> list;
                    string search = null;
                    Debug.WriteLine("---------------");
                    Debug.WriteLine("PageLoad");
                    if (Request.QueryString["Search"] != null)
                    {
                        Debug.WriteLine("SerchValueFound");
                        search = Request.QueryString["Search"];
                    }
                    if (Cache["MatchesCache"] == null)
                    {
                        Debug.WriteLine("Cache Loading");
                                        
                        try
                        {
                            list = new List<Match>
                            {
                                new Match{MatchId = 1, Date = 1, TimeStart = 1, AwayTeam = "the flying fijians", HomeTeam = "wallabies"},
                                new Match{MatchId = 2, Date = 1, TimeStart = 1, AwayTeam = "wallabies", HomeTeam = "all blacks"},
                                new Match{MatchId = 3, Date = 1, TimeStart = 1, AwayTeam = "springboks", HomeTeam = "all blacks"},
                            };
                                                    
                            Cache.Insert("MatchesCache", list, null, DateTime.Now.AddDays(1), System.Web.Caching.Cache.NoSlidingExpiration);
                        }
                        catch
                        {
                            Debug.WriteLine("Failed to update cache");
                        }                    
                    }
                    list = (List<Match>)Cache["MatchesCache"];
                    Debug.WriteLine("List loaded from Cache");
                    if (!string.IsNullOrEmpty(search))
                    {
                        Debug.WriteLine("Search is beeing done");
                        var newList = new List<Match>();
                    
                        foreach (var m in list)
                        {
                            if (m.AwayTeam.Contains(search) || m.HomeTeam.Contains(search))
                            {
                                newList.Add(m);
                            }
                        }
                        list = newList;
                    }
                    GridView1.DataSource = list;
                    GridView1.DataBind();                               
                    Debug.WriteLine("---------------");
                }            
            }
            protected void Button1_Click(object sender, EventArgs e)
            {
                Debug.WriteLine("Button Pressed");
                var s = ("~/Default.aspx");
            
                if (!string.IsNullOrEmpty(TextBox1.Text))
                {
                    s = (s + "?Search=" + TextBox1.Text);
                }
                Debug.WriteLine("Redirction adress:" + s);
                Response.Redirect(s, false);            
            }
        }
        public class Match
        {
            public int MatchId { get; set; }
            public int Date { get; set; }
            public int TimeStart { get; set; }
            public string HomeTeam { get; set; }
            public string AwayTeam { get; set; }                                         
        }
    }
