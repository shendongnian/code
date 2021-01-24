public int? Proyecto
    {
        get
        {
           int? id = null;
             //...
            else
            {
             //... 
               {
           this.Proyecto = id;
                }
                //...
            }
            return id;
        }
        
    }
    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {
            if (!this.Proyecto.HasValue)
            {
                //     
            }
        }
   //...
    }
