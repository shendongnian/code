    public DataTable fillZone()
    {
        string sql = "select location from zone";
        MySqlDataAdapter zonedapter = new MySqlDataAdapter(sql,conn);
        DataTable dt = new DataTable("zone");
        zonedapter.Fill(dt);                
        return dt;
    }
    public void fillcombo()
    {
         DataTable dt = fillZone();
         foreach (DataCell cell in dt)
         { 
           zonecb.add(cell.Value)
         }
    }
