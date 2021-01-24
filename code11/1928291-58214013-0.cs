csharp
private void InitializeComponent()
{
    // ...
    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyTestForm));
    // ...
    ((System.ComponentModel.ISupportInitialize)(this.rdp)).BeginInit();
    // ...
    // 
    // rdp
    // 
    this.rdp.Enabled = true;
    this.rdp.Location = new System.Drawing.Point(12, 12);
    this.rdp.Name = "rdp";
    this.rdp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdp.OcxState")));
    this.rdp.Size = new System.Drawing.Size(804, 602);
    this.rdp.TabIndex = 0;
    // ...
    ((System.ComponentModel.ISupportInitialize)(this.rdp)).EndInit();
    // ...
}
So, this is what I did foreach RDP in the loop of my question:
csharp
foreach (RDPData rdp in root.Value)
{
    AxMsRdpClient9NotSafeForScripting rdpClient = new AxMsRdpClient9NotSafeForScripting();
    ((System.ComponentModel.ISupportInitialize)(rdpClient)).BeginInit();
    System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RDPMultiTabForm));
    rdpClient.Enabled = true;
    rdpClient.Name = rdp.Alias;
    rdpClient.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("rdpClient.OcxState")));
    TabPage tab = new TabPage(rdp.Alias);
    rdpClient.Dock = DockStyle.Fill;
    tab.Controls.Add(rdpClient);
    tab.Dock = DockStyle.Fill;
    tabControl1.TabPages.Add(tab);
    ((System.ComponentModel.ISupportInitialize)(rdpClient)).EndInit();
    rdpClient.Server = rdp.Server;
    rdpClient.UserName = rdp.User;
    rdpClient.AdvancedSettings7.EnableCredSspSupport = true;
    IMsTscNonScriptable secured = (IMsTscNonScriptable)rdpClient.GetOcx();
    secured.ClearTextPassword = rdp.Password;
    rdpClient.Connect();
}
