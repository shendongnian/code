      <% if (Session["SessionUserImpersonate"] != null && Session["SessionUserImpersonate"] != "" && Session["SessionUserImpersonate"] == "Yes")
        {
            BLL.Models.User userold = new BLL.Models.User();
            userold = (BLL.Models.User)Session["SessionUserOld"];      
            %>
        <span class="FL">(Impersonated as <%=Website.Backoffice.SessionHelper.Session_User.UserName != null ? Website.Backoffice.SessionHelper.Session_User.UserName:"" %>  , </span>
       
        <form class="FL" id='frmid' action="/Index/Login?username=<%=userold.UserName%>&password=<%=userold.Password%>&IsImpersonate=No"  method="post">
                    <a class="TxtRed" style="cursor:pointer;" onclick="$('#frmid').submit(); return false;" > - finish impersonated session  </a>
                    </form>   
                    ) &nbsp;&nbsp;
        <%} %> 
      
 
    
 
   
