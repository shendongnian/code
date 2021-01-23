      <% if (Session["SessionUserImpersonate"] != null && Session["SessionUserImpersonate"] != "" && Session["SessionUserImpersonate"] == "Yes")
        {
            Highmark.BLL.Models.User userold = new Highmark.BLL.Models.User();
            userold = (Highmark.BLL.Models.User)Session["SessionUserOld"];      
            %>
        <span class="FL">(Impersonated as <%=Highmark.Website.Backoffice.SessionHelper.Session_User.UserName != null ? Highmark.Website.Backoffice.SessionHelper.Session_User.UserName:"" %>  , </span>
       
        <form class="FL" id='frmid' action="/Index/Login?username=<%=userold.UserName%>&password=<%=userold.Password%>&IsImpersonate=No"  method="post">
                    <a class="TxtRed" style="cursor:pointer;" onclick="$('#frmid').submit(); return false;" > - finish impersonated session  </a>
                    </form>   
                    ) &nbsp;&nbsp;
        <%} %> 
      
 
    
 
   
