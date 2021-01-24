    private void SomeGridView_KeyPress(object sender, KeyPressEventArgs e)
    {
        DataGridView DGV = SomeGridView;
    
        string curStr;
    
        bool isFirst = DGV.CurrentCell.EditedFormattedValue == null;
        curStr = isFirst ? "" : DGV.CurrentCell.EditedFormattedValue.ToString();
        Type type = DGV.CurrentCell.GetType();
        if (DGV.CurrentCell.GetType() == typeof(DataGridViewTextBoxCell))
        {
            DataGridViewTextBoxCell DGVTB = (DataGridViewTextBoxCell)DGV.CurrentCell;
            if (DGV.CurrentCell.EditType == typeof(DataGridViewTextBoxEditingControl))
                if(DGV.EditingControl != null)
                    charIndex = ((TextBox)DGV.EditingControl).SelectionStart;
        }
    
        switch ((GridDataEnum)DGV.CurrentCell.ColumnIndex)
        {
            case GridDataEnum.setpoint:
            case GridDataEnum.SlopePoint:
                e.Handled = !HelperUtils.isValidNumber(curStr, e.KeyChar, HelperUtils.TargetNumberTypeEnum.signedDouble, charIndex);
                break;
            case GridDataEnum.lowerX:
            case GridDataEnum.upperX:
            case GridDataEnum.TransX:
            case GridDataEnum.constY:
                e.Handled = !HelperUtils.isValidNumber(curStr, e.KeyChar, HelperUtils.TargetNumberTypeEnum.unsignedDouble, charIndex);
                break;
        }
    }
