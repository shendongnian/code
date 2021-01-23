    List<string> BindList = new List<string>();
    BindList.AddRange(ServiceName);
    BindList.AddRange(ServiceStatus);
    foreach(string item in BindList)
    {
    Datagridview1.Rows.Add(item.objSAVService,item.objSAVAdminService.....)
    }
