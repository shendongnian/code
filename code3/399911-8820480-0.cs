    string userc = GetContextInfo("User", "UserId");
    string tools = Dispatch.EitherField("selectedTools");
    string[] toolIds = tools.Split(',');
    foreach (string toolId in toolIds) 
    {
      Record recRelTool = new Record("RelatedTools");
      recRelTool.SetField("rato_CreatedBy", userc);
      recRelTool.SetField("rato_Status", "active");
      recRelTool.SetField("rato_server", pID);
      recRelTool.SetField("rato_tool", toolId);
      recRelTool.SaveChanges();
    }
    Dispatch.Redirect(Url("1453"));
