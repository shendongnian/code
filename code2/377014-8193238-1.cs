    private void BindLeaveMaster()
    {
         DataTable dt = HREmpLeave.GetSearch(null, null, null, null, true, null, null, null, null).Tables[0];
         try
         {
              if (dt.Rows.Count > 0)
              {
                   gvLeave.DataSource = dt;
                   gvLeave.DataBind();
              }
              else
              {
                   gvLeave.DataSource = null;
                   gvLeave.DataBind();
              }
         }
         catch (Exception oException)
         {
               oException.Message.ToString();
         }
         finally
         {
              dt = null;
        }
    }
