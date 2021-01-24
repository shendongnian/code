    private readonly List<string> _allTowns = new List<string>();
    public void AreaList()
    {
        _allTowns.Clear();
        using (DataTable dt = new DataTable())
        using (SqlDataAdapter adpt = new SqlDataAdapter("SELECT DISTINCT Town from tblAllPostCodes", sqlCon))
        {
            adpt.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                _allTowns.Add(dr["Town"].ToString());
            }
        }
        Area.ItemsSource = _allTowns;
    }
