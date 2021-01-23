    List<int> Chosen;
    public void Page_Load(object sender, EventArgs e)
    {
      if(Sesstion["Chosen"]==null)
        {
          Session["Chosen"]=new List<int>();
        }
      Chosen = (List<int>)Session["Chosen"];
    }
