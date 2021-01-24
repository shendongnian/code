    Button btn = new Button();
    btn.Id = "Id";
    btn.Text = "Something";
    btn.Click += new EventHandler(BtnHandler_Click);
    btnCell.Controls.Add(btn);
    
    row.Cells.Add(btnCell);
