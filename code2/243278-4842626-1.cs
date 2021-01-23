    public class AddManyControl : CompositeControl
    {
        private void AddControl(int index)
        {
            var div = new HtmlGenericControl("div");
            var textBox = new TextBox();
            textBox.ID = "tb" + index;
            div.Controls.Add(textBox);
            Controls.AddAt(index, div);
        }
        protected override void CreateChildControls()
        {
            for (int i = 0; i < ControlsCount; i++)
            {
                AddControl(i);
            }
            var btnAdd = new Button();
            btnAdd.ID = "Add";
            btnAdd.Text = "Add text box";
            btnAdd.Click += new EventHandler(btnAdd_Click);
            Controls.Add(btnAdd);
            var btnPostBack = new Button();
            btnPostBack.ID = "PostBack";
            btnPostBack.Text = "Do PostBack";
            Controls.Add(btnPostBack);
        }
        private int ControlsCount
        {
            get
            {
                object o = ViewState["ControlCount"];
                if (o != null)
                    return (int)o;
                return 0;
            }
            set
            {
                ViewState["ControlCount"] = value;
            }
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            int count = ControlsCount;
            AddControl(count);
            ControlsCount = count + 1;
        }
    }
