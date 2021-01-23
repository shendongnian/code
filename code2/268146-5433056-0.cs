            int[] values = {1,3,6};
            GridView1.DataSource = values;
            GridView1.DataBind();
            int total = 0;
            foreach (GridViewRow item in GridView1.Rows)
            {
                total += Convert.ToInt32(item.Cells[0].Text);
            }
            
            GridView1.FooterRow.Cells[0].Text = total.ToString();
