    <script runat="server">
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!X.IsAjaxRequest)
            {
                // Add individual Items
                this.ComboBox1.Items.Add(new ListItem("Region1", "England"));
                this.ComboBox1.Items.Add(new ListItem("Region2", "Scotland"));
                this.ComboBox1.Items.Add(new ListItem("Region3", "Wales"));
                // AddRange alternative
                // this.ComboBox1.Items.AddRange(new ListItem[] {
                //     new ListItem("Region1", "England"),
                //     new ListItem("Region2", "Scotland"),
                //     new ListItem("Region3", "Wales")
                // });
            }
        }
    </script>
    <ext:ComboBox ID="ComboBox1" runat="server" />
