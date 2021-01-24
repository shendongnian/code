    public class TableIdentificationException : Exception
    {
    }
    private void click(int y)
    {
        Edit();
        clear_invo();
        var tname = string.Empty;
        switch (str)
        {
            case "Pur":
                tname = "PurchaseT";
                break;
            case "GRO":
                tname = "Gro_Chln_T";
                break;
            case "Gri-Chln_T":
                tname = "GRI";
                break;
            case "Job":
                tname = "JobT";
                break;
            default:
                var ex = new TableIdentificationException();
                ex.Data.Add("LookupString", str);
                throw ex;
        }
        var bene_id = -1;
        using (var con = new SqlConnection(@"Data Source=ANSARI-PC\;Initial Catalog=BMS;Integrated Security=True"))
        {
            var sql1 = $"select * from [{tname}]";
            using (var sda1 = new SqlDataAdapter(sql1, con))
            {
                var dsi = new DataSet();
                sda1.Fill(dsi);
                try
                {
                    idtxt.Text = dsi.Tables[0].Rows[y][0].ToString();
                    bene_id = Convert.ToInt32(dsi.Tables[0].Rows[y][1]);
                }
                catch (Exception ex)
                {
                    if (idtxt.Text != null) MessageBox.Show(ex.Message);
                }
            }
        }
        load_bene(bene_id);
        var challan_id = $"{str}-{idtxt.Text}";
        Load_item(challan_id);
        No_Edit();
    }
