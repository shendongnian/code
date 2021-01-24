    override protected void OnInit(EventArgs e)
    {
        // Create dynamic controls here.
        // Use "using System.Web.UI.WebControls;"
        TextBox1 = new TextBox();
        TextBox1.ID = "TextBox1";
        TextBox1.Style["Position"] = "Absolute";
        TextBox1.Style["Top"] = "25px";
        TextBox1.Style["Left"] = "100px";
        Form1.Controls.Add(TextBox1);
    
        TextBox2 = new TextBox();
        TextBox2.ID = "TextBox2";
        TextBox2.Style["Position"] = "Absolute";
        TextBox2.Style["Top"] = "60px";
        TextBox2.Style["Left"] = "100px";
        Form1.Controls.Add(TextBox2);
    
        this.TextBox1.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
        this.TextBox2.TextChanged += new System.EventHandler(this.TextBox_TextChanged);
    
        // 
        // CODEGEN: This call is required by the ASP.NET Web Form Designer.
        // 
        InitializeComponent();
        base.OnInit(e);
    }
