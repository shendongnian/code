    protected void Page_Load(object sender, EventArgs e)
        {
            this.JavaScript.Text = string.Format("<script>setTimeout(\"{0}\", {1});</script>", 
                this.Page.GetPostBackClientEvent(this.btnRefresh, ""), 3000);
    
    
            ProcessStatus status= Class.GetProcessStatus(reference);
    
            lblCount.Text = status.Count.ToString();
           
    
    
            if (import.Status == (int)ProcessStatus.Status.Complete)
            {
                Globals.GoUrl("/Import/File/Map.aspx");
            }
        }
  
   
