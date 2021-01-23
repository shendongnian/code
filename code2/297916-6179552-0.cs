       using (SqlCommand statCmd = new SqlCommand(comnt, editConn))
        {
            SqlDataReader dr = statCmd.ExecuteReader();
           if( dr.Read())
            if (dr.GetInt32(0) > 0)
            {
                PanelComment.Visible = true;
                PanelQuote.Visible = false;
                LnbFid.Visible = false;
                LnbCrim.Visible = false;
                LnbEo.Visible = false;
                LnbEpl.Visible = false;
                LnbNot.Visible = false;
                LnbPriv.Visible = false;
                LnbPub.Visible = false;
    
            }
            else
            {
                PanelComment.Visible = false;
            }
    
        }
