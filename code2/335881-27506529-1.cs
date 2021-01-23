    public static Control GetAnyControlAt(this TableLayoutPanel panel, int column, int row)
    {
        foreach (Control control in panel.Controls)
        {
            var cellPosition = panel.GetCellPosition(control);
            if (cellPosition.Column == column && cellPosition.Row == row)
                return control;
        }
        return null;
    }
