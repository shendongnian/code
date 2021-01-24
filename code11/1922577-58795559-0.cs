<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckLoopQR.Default" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script type="text/javascript" src="//code.jquery.com/jquery-1.6.4.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
    <script type="text/javascript">
    $(window).load(function(){
      
    $("#checkAll").change(function () {
    $("input:checkbox").prop('checked', $(this).prop("checked"));
    });
    });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>QR Code Generator</h2>
            <div class="row">
                <div class="col-md-4">
                    <div class="form-group">
                        <label>Please Input Data</label>
                        <div class="input-group">
                            <asp:TextBox ID="txtQRCode" runat="server" CssClass="form-control"></asp:TextBox>
                            <div class="input-group-prepend">
                                <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-secondary" Text="Generate" OnClick="btnGenerate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <asp:Button ID="btnSelect" runat="server" CssClass="btn btn-secondary" Text="Display Text" OnClick="btnSelect_Click" /><br /><br />
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
            <asp:CheckBox ID="checkAll" runat="server" Font-Size="Large"/><asp:Label id="checkTextAll" runat="server" Font-Size="Large"></asp:Label><br /><br />
            <asp:CheckBoxList ID="CheckBox1" runat="server" Border="1"
            BorderColor="LightGray" Font-Size="Large"></asp:CheckBoxList>  
        </div>
    </form>
</body>
</html>
2. Default.aspx.cs (C# Code)
using System;
using System.Drawing;
using System.IO;
using ZXing.Common;
using ZXing;
using ZXing.QrCode;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
namespace CheckLoopQR
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.checkTextAll.Text = " Check All";
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string code = txtQRCode.Text;
            long num = Convert.ToInt64(code);
            int i;
            for (i = 1; i < 4; i++)
            {
                num += i;
                CheckBox1.Items.Add(new ListItem(" " + num));
            }
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
			if (CheckBox1.SelectedItem == null)
            {
                Response.Redirect("Default.aspx");
            }
            string[] texture = { "Selected Item Text1 : ", "Selected Item Text2 : ", "Selected Item Text3 : " };
            int a = 0;
            foreach (ListItem listItem in CheckBox1.Items)
            {
                if (listItem.Selected)
                {
                    a++;
                    string code = listItem.Text;
                    CheckBox1.Visible = false;
                    checkAll.Visible = false;
                    checkTextAll.Visible = false;
                    QrCodeEncodingOptions options = new QrCodeEncodingOptions();
                    options = new QrCodeEncodingOptions
                    {
                        DisableECI = true,
                        CharacterSet = "UTF-8",
                        Width = 150,
                        Height = 150,
                        Margin = 0,
                    };
                    var barcodeWriter = new BarcodeWriter();
                    barcodeWriter.Format = BarcodeFormat.QR_CODE;
                    barcodeWriter.Options = options;
                    System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
                    imgBarCode.Height = 150;
                    imgBarCode.Width = 150;
                    Label lblvalues = new Label();
                    lblvalues.Text += texture[a-1] + listItem.Text;
                    lblvalues.Font.Size = FontUnit.Large;
                    Label lblvalues2 = new Label();
                    lblvalues2.Text += texture[a-1] + listItem.Text;
                    lblvalues2.Font.Size = FontUnit.Large;
                    Label lblvalues3 = new Label();
                    lblvalues3.Text += texture[a-1] + listItem.Text;
                    lblvalues3.Font.Size = FontUnit.Large;
                    using (Bitmap bitMap = barcodeWriter.Write(code))
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                            byte[] byteImage = ms.ToArray();
                            imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                        }
                        PlaceHolder1.Controls.Add(imgBarCode);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues2);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                        PlaceHolder1.Controls.Add(lblvalues3);
                        PlaceHolder1.Controls.Add(new HtmlGenericControl("br"));
                    }
                }
                else
                {
                    //do something else 
                }
            }
        }
    }
}
