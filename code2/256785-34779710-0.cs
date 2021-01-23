    int NumFloorsCt = 10;
    LinkButton[] rgBL;
    HtmlGenericControl[] rgLI;
    
    /// <summary>
    /// set up an array of LinkButtons with "li" controls
    /// - each LinkButton click is handled by the same event handler
    /// </summary>
    void SetUpLinkButtons(List<FLOOR> listFloorRecs)
    {
      NumFloorsCt = 10;
      rgBL = new LinkButton[NumFloorsCt];
      rgLI = new HtmlGenericControl[NumFloorsCt];
      for (int i = 0; i < NumFloorsCt; i++)
      {
        rgBL[i] = new LinkButton();
        rgBL[i].ID = LB_ID_prefix + listFloorRecs[i].ID;
        rgBL[i].Click += new System.EventHandler(LB_fp_Click);
        rgBL[i].Text = listFloorRecs[i].DESCRIP;
        rgBL[i].ToolTip = "Click here to display floor info";
        rgLI[i] = new HtmlGenericControl("li");
        rgLI[i].Controls.Add(rgBL[i]);
        ulNoTree.Controls.Add(rgLI[i]);
      }
    }
    /// <summary>
    /// event handler for any of the link buttons
    /// </summary>
    protected void LB_fp_Click(object sender, EventArgs e)
    {
      LinkButton btn = (LinkButton)(sender);
      // do your action here
    }
