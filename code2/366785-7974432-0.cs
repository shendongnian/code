        private void gridControl1_EditorKeyDown(object sender, KeyEventArgs e)
        {
            GridView view = (sender as GridControl).FocusedView as GridView;
            VisualStyleElement.TextBox.TextEdit edit = view.ActiveEditor as VisualStyleElement.TextBox.TextEdit;
            if (edit == null) return;
            if (view.FocusedColumn.FieldName == "FirstName" && view.FocusedRowHandle % 2 == 0)
            {
                e.Handled = (e.KeyData == Keys.Right && edit.SelectionStart == edit.Text.Length) ||
                    (e.KeyData == Keys.Left && edit.SelectionStart == 0);
            }
        }
