     if (Request.QueryString["view"] != null && Request.QueryString["view"] != "")
     {
          body.Attributes["onload"] = "scroll('" + Request.QueryString["view"] + "');";
     }
     else //Probably redundant, but I have partial postbacks
     {
          body.Attributes.Remove("onload");
     }
