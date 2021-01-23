    var qry1 = dtDuplicate.AsEnumerable().Select(a => new { SchoolID = a["SchoolMID"].ToString()});
    var qry2 = dsValadateSchoolInfo.Tables[1].AsEnumerable().Select(b => new { SchoolID = ["SchoolMID"].ToString() });
    var exceptAB = qry1.Except(qry2);
    DataTable dtMisMatch = (from a in dtDuplicate.AsEnumerable()
                            join ab in exceptAB on a["SchoolMID"].ToString() equals ab.SchoolID
                            select a).CopyToDataTable();
