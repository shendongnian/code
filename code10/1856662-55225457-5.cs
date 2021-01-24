    private void TLPRemoveRow(TableLayoutPanel tlp, Control control)
    {
        int ctlRow = this.tlp1.GetRow(control);
        TLPRemoveRow(tlp, ctlRow);
    }
    private void TLPRemoveRow(TableLayoutPanel tlp, int row)
    {
        if (row < this.tlp1.RowCount - 1) {
            for (int i = row; i < this.tlp1.RowCount - 1; i++) {
                tlp.SetRow(tlp.GetControlFromPosition(0, i + 1), i);
            }
        }
        tlp.RowCount -= 1;
    }
