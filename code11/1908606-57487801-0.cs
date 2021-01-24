    public bool deleteIncidentCloseOut(int ID)
    {
      try
      {
        using (ESSDataContext ctx = new ESSDataContext())
        {
          this.GetCurrentAuditScope().SetCustomField("Dynamic", new { IncidentCloseOutID = ID });
          ctx.DeleteIncidentCloseOut(ID);
          return true;
        }
      }
      catch (Exception ex)
      {
        ...
      }
    }
