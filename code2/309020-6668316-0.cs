    private void riSpinEdit_EditValueChanged(object sender, EventArgs e)
            {
                TextEdit edit = grdReceiveGoods.FocusedView.ActiveEditor as TextEdit;
                if (edit != null)
                {
                    int len = edit.SelectionLength;
                    int start = edit.SelectionStart;
                    grdReceiveGoods.FocusedView.PostEditor();
                    edit.SelectionLength = len;
                    edit.SelectionStart = start;
                }
            }
