    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            var oGame = from g in myDB.Game
                        group g by g.GameName into result
                        select new { GameID = result.Key, GameName = result };
    
            ListView1.DataSource = oGame;
            ListView1.DataBind();
        }
    }
    
    protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        HiddenField hdnGameID = (HiddenField)e.Item.FindControl("hdnGameID");
        RadioButtonList rblTeam = (RadioButtonList)e.Item.FindControl("rblTeam");
    
        var oTeam = from t in myDB.Game
                    where t.GameID == hdnGameID.Value
                    select t;
    
        rblTeam.DataSource = oTeam;
        rblTeam.DataBind();
    }
