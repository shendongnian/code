    // Fetch the columns in the relationship
    var parentColumn = DataSet1.Tables["Department"].Columns["(DepartmentID"];
    var childColumn = DataSet1.Tables["Projects"].Columns["(DepartmentID"];
    // Create the relation
    var relation = new DataRelation("ProjectsDepartments", parentColumn, childColumn);
    // And add it to the dataset
    DataSet1.Relations.Add(relation);
