     DataList dli = (DataList)Page.FindControl("DL_Pro_Result");
     foreach (Control child in dli.Controls)
     {
      foreach (Control child1 in child.Controls)
      {
       try
       {
        if ((DataList)child1.FindControl("DL_Gro_Result") != null)
        {
         DataList dli = (DataList)child1.FindControl("DL_Gro_Result");
        }
       }
       catch (Exception e)
       {
        Trace.Warn("Exception!!", e.ToString() + "Trying next iteration");
       }
      }
     }
