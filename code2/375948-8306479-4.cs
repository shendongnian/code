    [WebMethod]
       public static string Rewards()
       {
           return RenderControl("~/controls/rewardsControl.ascx");
       }
    
    [WebMethod]
       public static string Coupons()
       {
           return RenderControl("~/controls/couponsControl.ascx");
       }    
    ...
