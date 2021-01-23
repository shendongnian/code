    #region Using Statements:
    using System;
    using System.Windows.Forms;
    using System.Security.Permissions;
    #endregion
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]
    public partial class Form1 : Form
    {
    public Form1()
    {
    InitializeComponent();
    // WebBrowser Configuration:
    webBrowser1.ObjectForScripting = this;
    webBrowser1.AllowWebBrowserDrop = false;
    webBrowser1.ScriptErrorsSuppressed = true;
    webBrowser1.WebBrowserShortcutsEnabled = false;
    webBrowser1.IsWebBrowserContextMenuEnabled = false;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
    webBrowser1.Navigate("https://www.google.com/");
    }
    }
