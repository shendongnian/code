    <script type="text/javascript">
    <!--
    function setSessionVariable(valueToSetTo)
    {
     __doPostBack('SetSessionVariable', valueToSetTo);
    }
    // -->
    </script>
    private void Page_Load(object sender, System.EventArgs e)
    {
     // Insure that the __doPostBack() JavaScript method is created...
     this.GetPostBackEventReference(this, string.Empty);
    
     if ( this.IsPostBack )
     {
      string eventTarget = (this.Request["__EVENTTARGET"] == null) ? string.Empty : this.Request["__EVENTTARGET"];
      string eventArgument = (this.Request["__EVENTARGUMENT"] == null) ? string.Empty : this.Request["__EVENTARGUMENT"];
    
      if ( eventTarget == "SetSessionVariable" )
      {
       Session["someSessionKey"] = eventArgument;
      }
     }
    }
