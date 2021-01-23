    public class DataGridWithFilter : DataGridView
    {
        protected override void OnColumnAdded(DataGridViewColumnEventArgs e)
        {
            var header = new DataGridFilterHeader();
            header.FilterButtonClicked += new EventHandler<ColumnFilterClickedEventArg>(header_FilterButtonClicked);
            e.Column.HeaderCell = header;
            base.OnColumnAdded(e);
        }
    
        void header_FilterButtonClicked(object sender, ColumnFilterClickedEventArg e)
        {
            // open a popup on the bottom-left corner of the
            // filter button
            // here's we add a simple hello world textbox, but you should add your filter control
            TextBox innerCtrl = new TextBox();
            innerCtrl.Text = "Hello World !";
            innerCtrl.Size = new System.Drawing.Size(100, 30);
    
            var popup = new ToolStripDropDown();
            popup.AutoSize = false;
            popup.Margin = Padding.Empty;
            popup.Padding = Padding.Empty;
            ToolStripControlHost host = new ToolStripControlHost(innerCtrl);
            host.Margin = Padding.Empty;
            host.Padding = Padding.Empty;
            host.AutoSize = false;
            host.Size = innerCtrl.Size;
            popup.Size = innerCtrl.Size;
            popup.Items.Add(host);
    
            // show the popup
            popup.Show(this, e.ButtonRectangle.X, e.ButtonRectangle.Bottom);
        }
    }
