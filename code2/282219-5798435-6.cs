    public partial class DynamicControls : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                for (var i = 0; i < TextBoxCount; i++)
                    AddTextBox(i);
            }
        }
    
        protected void btnAddTextBox_Click(object sender, EventArgs e)
        {
            AddTextBox(TextBoxCount);
            TextBoxCount++;
        }
    
        protected void btnWriteValues_Click(object sender, EventArgs e)
        {
            foreach(var control in phControls.Controls)
            {
                var panel = control as Panel;
                if (panel == null || !panel.Visible) continue;
                foreach (var control2 in panel.Controls)
                {
                    var textBox = control2 as TextBox;
                    if (textBox == null) continue;
                    Response.Write(string.Concat(textBox.Text, "<br />"));
                }
            }
        }
    
        private int TextBoxCount
        {
            get 
            {
                var count = ViewState["txtBoxCount"];
                return (count == null) ? 0 : (int) count;
            }
            set { ViewState["txtBoxCount"] = value; }
        }
    
        private void AddTextBox(int index)
        {
            var panel = new Panel();
            panel.Controls.Add(new TextBox {ID = string.Concat("txtDynamic", index)});
            var btn = new Button { Text="Remove" };
            btn.Click += btnRemove_Click;
            panel.Controls.Add(btn);
            phControls.Controls.Add(panel);
        }
    
        private void btnRemove_Click(object sender, EventArgs e)
        {
            var btnRemove = sender as Button;
            if (btnRemove == null) return;
            btnRemove.Parent.Visible = false;
        }
    }
