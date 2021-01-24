    private void Area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AreasSelected.Text = "";
            foreach (object area in Area.SelectedItems)
            {
                AreasSelected.Text += (AreasSelected.Text == "" ? "" : " , ") + area.ToString();
            }
    
    
                DataTable dt = new DataTable();
                SqlDataAdapter adpt = new SqlDataAdapter("SELECT PostCode,Town FROM tblAllPostCodes where Town in (" + string.Join(",", Area.SelectedItems.Cast<string>().Select(si => "'" + si.ToString() + "'").ToArray()) + ")", sqlConTwo);
                adpt.Fill(dt);
    
                foreach (DataRow dr in dt.Rows)
                {
                    AreaPostCode.Items.Add(dr["PostCode"].ToString());
                }
    
            }
