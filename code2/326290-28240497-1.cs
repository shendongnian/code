            var dbe = new DBEngine();
            Database db = dbe.OpenDatabase(@"C:\tmp\access database file.accdb");
            try
            {
                Recordset rstMain = db.OpenRecordset(
                        "SELECT `Attachment` FROM `table name`",
                        RecordsetTypeEnum.dbOpenDynaset);
                while (!rstMain.EOF)
                {
                    Recordset2 rstAttach = rstMain.Fields["Attachment"].Value;
                    rstAttach.OpenRecordset();
                    while (!rstAttach.EOF)
                    {
                        Field2 fldAttach = (Field2)rstAttach.Fields["FileData"];
                        string fileName = rstAttach.Fields["FileName"].Value.ToString();
                        fldAttach.SaveToFile(@"C:\tmp\" + fileName);
                        rstAttach.MoveNext();
                    }
                    rstAttach.Close();
                    rstMain.MoveNext();
                }
                rstMain.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
