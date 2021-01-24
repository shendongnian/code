    protected void Page_Load(object sender, EventArgs e)
    {
        if(Page.IsPostBack)
        {
            
           if(Request["index1"] !=null)
           {
               //then first button posted back
               //Request["index1"] will return the value property of the button index1 if it posted back
           } else if(Request["index2"] !=null)
           {
               //then first button posted back
               //Request["index2"] will return the value property of the button index2 if it posted back
           } else if(Request["index3"] !=null)
           {
                //then first button posted back
                //Request["index3"] will return the value property of the button index3 if it posted back
           }
        }
    }
