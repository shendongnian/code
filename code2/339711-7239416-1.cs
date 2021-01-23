    // Get a list of all the id's i need by:
    // grouping by CustID, and then selecting Max ID from each group.
    var distinctLatest = (from x in ee.Records
                              group x by x.CustID into grp 
                              select grp.Max(g => g.id)).ToArray();
    // List<Record> result = new List<Record>();
    //now we can retrieve individual records using the ID's retrieved above
    // foreach (int i in distinctLatest)
    // {
    //    var res = from g in ee.Records where g.id == i select g;
    //    var arr = res.ToArray();
    //    result.Add(res.First());
    // }
    // alternate version of foreach
    dgvLatestDistinctRec.DataSource = from g in ee.Records
                                               join i in distinctLatest
                                               on g.id equals i
                                               select g;
