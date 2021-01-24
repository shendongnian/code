<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="QRCode_Demo.QRCode" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
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
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder><br /><br />
            <asp:RadioButtonList 
            ID="CheckBox1"
            runat="server"
            RepeatDirection="Vertical"
            Border="1"
            BorderColor="LightGray"
            Font-Size="Large"></asp:RadioButtonList>  
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
namespace QRCode_Demo
{
    public partial class QRCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void btnSelect_Click(object sender, EventArgs e)
        {
            string code = txtQRCode.Text;
            int i;
            for (i = 1; i < 11; i++)
            {
                CheckBox1.Items.Add(new ListItem("&nbsp;&nbsp;" + code));
            } 
        }
        protected void btnGenerate_Click(object sender, EventArgs e)
        {
            string code = txtQRCode.Text;
            CheckBox1.Visible = false;
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
            using (Bitmap bitMap = barcodeWriter.Write(code))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    byte[] byteImage = ms.ToArray();
                    imgBarCode.ImageUrl = "data:image/png;base64," + Convert.ToBase64String(byteImage);
                }
                PlaceHolder1.Controls.Add(imgBarCode);
            }
        }
    }
}
