    public class FirstColumnHeaderGridView : GridView
    {
        protected override void InitializeRow(GridViewRow row, DataControlField[] fields)
        {
            DataControlFieldCell cell = new DataControlFieldHeaderCell(fields[0]);
            DataControlCellType header = DataControlCellType.DataCell;
            fields[0].InitializeCell(cell, header, row.RowState, row.RowIndex);
            row.Cells.Add(cell);
            DataControlField[] newFields = new DataControlField[fields.Length - 1];
            for (int i = 1; i < fields.Length; i++)
            {
                newFields[i - 1] = fields[i];
            }
            base.InitializeRow(row, newFields);
        }
    }
