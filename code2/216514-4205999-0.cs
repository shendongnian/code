    private VScrollBar _verticalScrollBar;
    private HScrollBar _horizontalScrollBar;
    foreach (Control c in _dataGridView.Controls)
        {
            if (c is VScrollBar)
            {
                 _verticalScrollBar = c as VScrollBar;
                 if (_horizontalScrollBar!=null)
                 {
                     break;
                 }
            }
            if (c is HScrollBar)
            {
                 _horizontalScrollBar = c as HScrollBar;
                 if (_verticalScrollBar != null)
                 {
                    break;
                 }
            }
        }
