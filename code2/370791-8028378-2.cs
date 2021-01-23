    DataTable custTable = custDS.Tables["Customers"];
    UniqueConstraint custUnique = new UniqueConstraint(new DataColumn[] 
        {custTable.Columns["CustomerID"], 
        custTable.Columns["CompanyName"]});
    custDS.Tables["Customers"].Constraints.Add(custUnique);
