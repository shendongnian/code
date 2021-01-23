    var directory = Dts.Variables["User::SourceDir"].Value.ToString();
    DirectoryInfo directoryInfo = new DirectoryInfo(directory);
    var result = directoryInfo.GetFiles("*.xml", SearchOption.AllDirectories).OrderBy(t => t.LastWriteTime).ToList();
    DataTable dsSorted = new DataTable();
    
    DataColumn dc = new DataColumn("Value");
    dsSorted.Columns.Add(dc);
    foreach (FileInfo item in result)
    {
        DataRow dr = dsSorted.NewRow();
        dr[0] = directory  + item ;
        dsSorted.Rows.Add(dr);
    }
    
    // lastModified = file.LastWriteTime;
    Dts.Variables["User::FileNamesSorted"].Value = dsSorted;
    
    // MessageBox.Show(Dts.Variables["User::FileNamesSorted"].Value.ToString());
    Dts.TaskResult = (int)ScriptResults.Success;
