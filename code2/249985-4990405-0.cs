    public partial class _Default : System.Web.UI.Page
    {
       private int myValue
    {
        get
        {
          var value = ViewState["myValue"];
          return null == value ? 0: (int)value;
        }
        set
        {
           ViewState["myValue"] = value;
        }
    }
    
    
         protected void Button2_Click(object sender, EventArgs e)
        {
    
            myValue = myValue + 1;
            Label2.Text = myValue.ToString();
    
        }
    
    }
