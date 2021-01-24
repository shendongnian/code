    DataTable dt1 = new DataTable();
    dt1.Columns.Add("ID");
    dt1.Columns.Add("CSV");
    dt1.Rows.Add(new object[] { "1", "[{\"@odata.type\":\"#Microsoft.Azure\",\"Claims\",\"DisplayName1\",\"Department\"}]" } );
    DataTable dt2 = new DataTable();
    dt2.Columns.Add("ID");
    dt2.Columns.Add("Provider");
    dt2.Columns.Add("Department");
    dt2.Columns.Add("Displayname");
    dt2.Columns.Add("OtherDept");
    
    foreach(DataRow ro in dt1.Rows){
      string csv = ro[1].ToString();
      csv = csv.Trim('[',']','{','}','"'); //remove leading and trailing chars that mess up our splitting
      string bits = csv.Split(new []{"},{"}); //split on a string delimiter of "},{". note: new[]{"abc","def"} is c# shorthand to declare an array of strings containing [0]="abc" and [1]="def"
      // our dt2 has 5 columns
      dt2.Rows.Add(new object[] {
           ro["ID"],
           bits[1],
           bits[2],
           bits[3],
           bits[4]
         }
      );
    }
