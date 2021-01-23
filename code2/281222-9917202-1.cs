    void Initialize()
    {
        CustomTextBoxColumn colText = new CustomTextBoxColumn();
        colText.DataPropertyName = colText.Name = columnTextName;
        colText.HeaderText = columnTextAlias;
        colText.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        this.Columns.Add(colText);
        DataGridViewTextBoxColumn colText2 = new DataGridViewTextBoxColumn();
        colText2.DataPropertyName = colText2.Name = columnText2Name;
        colText2.HeaderText = columnText2Alias;
        colText2.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
        this.Columns.Add(colText2);
    }
    protected override void WndProc(ref Message m)
    {
        //the enter key is sent by edit control
        if (m.Msg == Native.WM_KEYDOWN)
        {
            if ((ModifierKeys & Keys.Shift) == 0)
            {
                Keys key = (Keys)m.WParam;
                if (key == Keys.Enter)
                {
                    MoveToNextCell();
                    m.Result = IntPtr.Zero;
                    return;
                }
            }
        }
        base.WndProc(ref m);
    }
    //move the focus to the next cell in same row or to the first cell in next row then begin editing
    public void MoveToNextCell()
    {
        int CurrentColumn, CurrentRow;
        CurrentColumn = this.CurrentCell.ColumnIndex;
        CurrentRow = this.CurrentCell.RowIndex;
        if (CurrentColumn == this.Columns.Count - 1 && CurrentRow != this.Rows.Count - 1)
        {
            this.CurrentCell = Rows[CurrentRow + 1].Cells[1];//0 index is for No and readonly
            this.BeginEdit(false);
        }
        else if(CurrentRow != this.Rows.Count - 1)
        {
            base.ProcessDataGridViewKey(new KeyEventArgs(Keys.Tab));
            this.BeginEdit(false);
        }
    }
