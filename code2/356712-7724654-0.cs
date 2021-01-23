     protected void RadGrid1_PreRender(object sender, EventArgs e)
        {
            foreach (GridDataItem it in RadGrid1.EditItems)
            {
                TextBox sv = (TextBox)it["POZ_Stawka_VAT"].Controls[0];
                if (sv.Text=="-1")
                sv.Text = "zw";
            }
        }
         protected void RadGrid1_DataBinding(object sender, EventArgs e)
        {
            for (int i = 0; i < RadGrid1.PageSize; i++)
            {
                RadGrid1.EditIndexes.Add(i);
            }
         
        }
