      var reader = sqlcmdSomeQueryCommand.ExecuteReader();
      var columns = new List<string>();
      //get all the field names  from the Columns var 
      for (int intCounter = 0; intCounter < reader.FieldCount; intCounter++)
      {
          columns.Add(reader.GetName(intCounter));
      }
      strarryTmpString = columns.ToArray();
      string TmpFields = string.Join(", ", strarryTmpString);
      columns.Clear();
      columns.Add(TmpFields); 
    
      //you can save the TmpFieldList to later add the rest of your comma delimited fields 
  
    write line by line in a foreach loop or use the List<string> object .foreach(delegate(string delString)
    {
      someStreamWriterObject.WriteLine(delString)
    }); 
