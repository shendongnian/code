    [Serializable]
    public class ColumnInfo
    {
        public string Name;
        public int Index;       
    }
    ArrayList array = new ArrayList();
    foreach(DataGridViewColumn column in datagridView1.Columns)
    {
        ColumnInfo ci = new ColumnInfo();
        ci.Name = column.Name;
        //ci.Index = column.Index; //decide how to get column index
        array.Add(ci);
    }
    using (FileStream file = new FileStream("test.xml", FileMode.Create))
    {
         SoapFormatter formatter = new SoapFormatter();
         formatter.Serialize(file, array);
    }
