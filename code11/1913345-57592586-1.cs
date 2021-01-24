    public class ProcessHtml()
    {
        List<Player> playersList = new List<Player>();
        
        //Get your HTML loaded from a URL. Giving me SSL exceptions so took a different route
        //var url = "https://lichess.org/player/top/200/bullet";
        //var web = new HtmlWeb();
        //var doc = web.Load(url);
        
        //Get your HTML loaded as a file in my case
        var doc = new HtmlDocument();
        doc.Load("C:\\Users\\Rahul\\Downloads\\CkBsZtvf.html", Encoding.UTF8);
    
        foreach (HtmlNode table in doc.DocumentNode.SelectNodes("//tbody"))
        {
            foreach (HtmlNode row in table.SelectNodes("tr"))
            {
                int i = 0;
                Player player = new Player();
                //Since there are 4 rounds per tr, hence get only what is required based on loop condition
                foreach (HtmlNode cell in row.SelectNodes("th|td"))
                {                      
                    if(i==1)
                    {
                        player.username = cell.InnerText;
                    }
                    if(i==2)
                    {
                        player.rating = Convert.ToDouble(cell.InnerText);
                    }
                    if(i==3)
                    {
                        player.title = cell.InnerText;
                    }                                              
                    i++;
                }
                playersList.Add(player);
            }
        }
    
        var finalplayerListCopy = playersList;  
    }
    public class Player 
    {
      public string username;
      public double rating;
      public string title;
    }
      
