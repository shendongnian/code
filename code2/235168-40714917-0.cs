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
    webBrowser1.AllowWebBrowserDrop = false;
    webBrowser1.IsWebBrowserContextMenuEnabled = false;
    webBrowser1.WebBrowserShortcutsEnabled = false;
    webBrowser1.ObjectForScripting = this;
    webBrowser1.ScriptErrorsSuppressed = true;
    }
    private void Form1_Load(object sender, EventArgs e)
    {
    webBrowser1.Navigate("https://www.google.com/");
    }
    }
