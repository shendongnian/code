      DataTable dataTabletest1 = dataSet.Tables.Add("Test1");
      DataTable dataTabletest2 = dataSet.Tables.Add("Test2");
      DataTable dataTabletest3 = dataSet.Tables.Add("Test3");
      dataAdaptertest1.Fill(dataTabletest1);
      dataAdaptertest2.Fill(dataTabletest2);
      dataAdaptertest3.Fill(dataTabletest3);
