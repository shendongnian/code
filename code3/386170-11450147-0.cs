    private void MyGridEX_LoadingRow(object sender, Janus.Windows.GridEX.RowLoadEventArgs e)
        {
            if (e.Row.RowType == Janus.Windows.GridEX.RowType.Record)
            {
                if ((bool)e.Row.Cells[0].Value)
                {
                    Janus.Windows.GridEX.GridEXFormatStyle style = new Janus.Windows.GridEX.GridEXFormatStyle();
                    style.ForeColor = Color.Red;
                    e.Row.RowStyle = style;
                }
            }
        }
