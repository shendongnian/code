     internal static void AddCheckboxes(System.Web.UI.WebControls.GridView gv,IEnumerable<int> checkedRows)
        {
            foreach (var item in gv.Rows.Cast<System.Web.UI.WebControls.GridViewRow>().Select(c => c.Cells[0]).Where(cell => cell.Controls.Count == 0).WithIndex())
                item.Item1.Controls.Add(new System.Web.UI.WebControls.CheckBox() { ClientIDMode = System.Web.UI.ClientIDMode.Static, ID = "ckUpdate" + item.Item2, Checked = checkedRows != null && checkedRows.Contains(item.Item2) });
        }
