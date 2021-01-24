    private void btnAdd_OnClick(object sender, EventArgs e)
        {
            string Name_Column1 = txtUomtyp.Text;
            string Name_Column2 = txtUomDesc.Text;
            string[] row = { Column1, Column2};
            DatGridView.Rows.Add(row);
        }
