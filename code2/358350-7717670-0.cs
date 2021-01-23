        <%@ Page Language="C#" %>
        <html xmlns="http://www.w3.org/1999/xhtml">
         <head id="Head1" runat="server">
           <script runat="server">
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!this.IsPostBack)
                this.AddNodes(this.trvCategories.Nodes, 0, this.LoadData());
        }
        private void AddNodes(TreeNodeCollection nodes, int level, System.Data.DataTable dt)
        {
            string filterExp = string.Format("ParentID='{0}'", level);
            foreach (System.Data.DataRow r in dt.Select(filterExp))
            {
                TreeNode item = new TreeNode()
                {
                    Text = r[1].ToString(),
                    Value = r[2].ToString()
                };
                this.AddNodes(item.ChildNodes, int.Parse(r[0].ToString()), dt);
                nodes.Add(item);
            }
        }
        private System.Data.DataTable LoadData()
        {
            ///
            /// For the simplicity I do build the datatable dynamically,
            /// But you may get this data from the DATABASE
            ///
            System.Data.DataTable dt = new System.Data.DataTable();
            dt.Columns.Add("ID", String.Empty.GetType());
            dt.Columns.Add("[Name]", String.Empty.GetType());
            dt.Columns.Add("[Value]", String.Empty.GetType());
            dt.Columns.Add("ParentID", String.Empty.GetType());
            dt.Columns.Add("[Order]", String.Empty.GetType());
            int index = 9;
            for (int i = 0; i < 1100; i++)
            {
                string item = "{0},Item{1},Value{1},{2},{1}";
                if (i < 110)
                {
                    index = i < 10 ? 0 : int.Parse(Math.Ceiling((decimal)i / 10).ToString());
                    dt.Rows.Add((string.Format(item, i + 1, i, index)).Split(char.Parse(",")));
                }
                else
                {
                    if (i % 10 == 0) index++;
                    dt.Rows.Add((string.Format(item, i + 1, i, index)).Split(char.Parse(",")));
                }
            }
            return dt;
        }
    </script>
