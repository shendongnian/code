     protected void listadoImg_DataBound(object sender, ListViewItemEventArgs e)
        {
            Label lblPrecioOfe;
            
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                lblPrecioOfe = (Label)e.Item.FindControl("lblPrecioOferta");
                System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
                string precioPub = rowView["precioPublicacion"].ToString();
                if (precioPub == "")
                {
                    lblPrecioOfe.Text = "";
                }
            }
            HtmlButton bot = (HtmlButton)e.Item.FindControl("btnAceptado1");
            HtmlButton bot2 = (HtmlButton)e.Item.FindControl("btnAceptado2");
            HtmlButton bot3 = (HtmlButton)e.Item.FindControl("btnRechazado1");
            HtmlButton bot4 = (HtmlButton)e.Item.FindControl("btnRechazado2");
            bot.Attributes.Add("onclick", "CambiarAceptado1(" + bot.ClientID.Substring(bot.ClientID.ToString().Length -1)+")");
            bot2.Attributes.Add("onclick", "CambiarAceptado2(" + bot.ClientID.Substring(bot.ClientID.ToString().Length - 1) + ")");
            bot3.Attributes.Add("onclick", "CambiarRechazado1(" + bot.ClientID.Substring(bot.ClientID.ToString().Length - 1) + ")");
            bot4.Attributes.Add("onclick", "CambiarRechazado2(" + bot.ClientID.Substring(bot.ClientID.ToString().Length - 1) + ")");
        }
