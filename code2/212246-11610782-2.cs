    public int LoadType{get;set;}
    
    private void CustomerPage_Load(object sender, EventArgs e)
            {
                
                if (LoadType == 1)
                {
                    this.button1.Visible = false;
                  }
    }
