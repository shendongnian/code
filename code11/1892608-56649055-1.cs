     protected void Txt_TextChanged(object sender, EventArgs e)
            {
                TextBox Txt_Ales = GridView1.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].FindControl("Txt_Ales") as TextBox;
                TextBox txt_Dil = GridView1.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].FindControl("txt_Dil") as TextBox;
                Label lbl_Toplam = GridView1.Rows[((sender as TextBox).NamingContainer as GridViewRow).RowIndex].FindControl("lbl_Toplam") as Label;
    
                int num1, num2 = 0;
                if (Txt_Ales != null && txt_Dil != null && lbl_Toplam != null)
                {
                    int.TryParse(Txt_Ales.Text, out num1);
                    int.TryParse(txt_Dil.Text, out num2);
                    lbl_Toplam.Text = (num1 + num2).ToString();
                }
            }
