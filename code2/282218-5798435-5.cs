    using System;
    using System.Web.UI.WebControls;
    
    namespace MyAspnetApp
    {
        public partial class DynamicControls : System.Web.UI.Page
        {
            protected void Page_Load(object sender, EventArgs e)
            {
                //Recreate textbox controls
                if(Page.IsPostBack)
                {
                    for (var i = 0; i < TextBoxCount; i++)
                        AddTextBox(i);
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
                var txt = new TextBox {ID = string.Concat("txtDynamic", index)};
                txt.Style.Add("display", "block");
                phControls.Controls.Add(txt);
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
                    var textBox = control as TextBox;
                    if (textBox == null) continue;
                    Response.Write(string.Concat(textBox.Text, "<br />"));
                }
            }
        }
    }
