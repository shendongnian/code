    SqlConnection editConn1 = new SqlConnection(connectionString);
    SqlConnection editConn2 = new SqlConnection(connectionString);
    editConn1.Open();
    editConn2.Open();
    
    SqlCommand comntCmd = new SqlCommand(comnt, editConn1);
    SqlDataReader dr = comntCmd.ExecuteReader();
    dr.Read();
    var c = dr.GetInt32(0);
    if (c > 0)
    {
        PanelQuote.Visible = false;
        SqlCommand prodcmd = new SqlCommand(product, editConn2);
        SqlDataReader drpan = prodcmd.ExecuteReader();
        drpan.Read();
        var d = drpan.GetInt32(0);
        switch (d)
        {
            case 1:
                LnbEpl.Enabled = false;
                break;
            case 2:
                LnbFid.Enabled = false;
                break;
            case 3:
                LnbCrim.Enabled = false;
                break;
            case 4:
                LnbPub.Enabled = false;
                break;
            case 5:
                LnbPriv.Enabled = false;
                break;
            case 6:
                LnbNot.Enabled = false;
                break;
            case 7:
                LnbEo.Enabled = false;
                break;
            default:
                break;
        }
    }
    else
    {
        PanelComment.Visible = false;
    }
