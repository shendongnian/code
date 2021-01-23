    BindingSource bindingSource = new BindingSource(PS.PaperSizes, null);
    lueSizes.Properties.DataSource = bindingSource;
    lueSizes.Properties.Columns.Add(new LookUpColumnInfo("PaperName", "Größe"));
    lueSizes.Properties.DisplayMember = "PaperName";
    foreach (PaperSize size in bindingSource)
        if (size.RawKind == BinSettings.SizeRawKind)
        {
            lueSizes.EditValue = size;
            break;
        }
------
    private void lueSizes_EditValueChanged(object sender, EventArgs e)
    {
        PaperSize size = lueSizes.EditValue as PaperSize;
        Update(size);
    }
