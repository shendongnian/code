                dt1 = (from table1 in ds1.Tables[0].AsEnumerable()
                             join table2 in dt.AsEnumerable()
                             on (string)table1["PracticeCode"] equals (string)table2["PracticeCode"]
                            select dt1.LoadDataRow(new object[]
                            {
                                (string)table1["PracticeCode"],
                                (string)table1["PracticeName"],
                                (int)table1["High"],
                                (int)table1["Medium"],
                                (string)table2["username"],
                                (string)table2["MIAlertHeader"],
                                (string)table2["MIAlertFooter"]
                            }, false)).CopyToDataTable();
