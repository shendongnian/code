        private void sheetCalendar_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (CurrentRota == null)
            {
                return;
            }
            /* A word of explanation is needed. We retrieve the DataGridView from sender
             * and we access the cell in question directly. 
             * MSDN advices against it -
             * "to avoid performance penalties When handling this event,
             * access the cell through the parameters of the event handler
             * rather than accessing the cell directly."
             * 
             * The problem is that we don't want to set the same colour to the same cell
             * over and over again.
             * And e.CellStyle always "forgets" what colour the call had had! */
            var dgrid = sender as DataGridView;
            var _col = e.ColumnIndex; 
            var _row = e.RowIndex; 
            var _highlight = (((Rota) sheetCalendar.Rows[e.RowIndex].DataBoundItem).Monday ==
                              CurrentRota.Monday);
            var color = _highlight ?
                                       Settings.Default.DGRIDCalendar_CurrentlyEditedBackColor :
                                                                                                   SystemColors.Window;
            if (dgrid[_col, _row].Style.BackColor != color)
                dgrid[_col, _row].Style.BackColor = color;
            
        }
