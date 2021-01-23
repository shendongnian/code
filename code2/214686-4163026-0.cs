    //Code for page a[a.aspx]
     protected void Page_Load(object sender, EventArgs e)
      {
        if(Session["a"]==null)
       {
         Session["a"]="Some Value";
       }
       else
       {
         // do code if user visit the page again.
       } 
      }
