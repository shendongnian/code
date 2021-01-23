    Color blue  = ColorTranslator.FromHtml("#CCFFFF");
    Color red = ColorTranslator.FromHtml("#FFCCFF");
    Color letters = Color.Black;
    
    foreach (DataGridViewRow r in datagridIncome.Rows)
    {
        if (r.Cells[5].Value.ToString().Contains("1")) { 
            r.DefaultCellStyle.BackColor = blue;
            r.DefaultCellStyle.SelectionBackColor = blue;
            r.DefaultCellStyle.SelectionForeColor = letters;
        }
        else { 
            r.DefaultCellStyle.BackColor = red;
            r.DefaultCellStyle.SelectionBackColor = red;
            r.DefaultCellStyle.SelectionForeColor = letters;
        }
    }
