browser.AddressChanged += OnBrowserAddressChanged;
Define `OnBrowserAddressChanged` body to chagne `RichBoxText` value:
this.InvokeOnUiThreadIfRequired(() => richTextBox1.Text = e.Address);
**Done**
Here is the complete example:
using CefSharp;
using CefSharp.WinForms;
using CefSharp.WinForms.Internals;
using System;
using System.Windows.Forms;
namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly ChromiumWebBrowser browser;
        public Form1()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser("www.google.com")
            {
                Dock = DockStyle.Fill,
            };
            browser.AddressChanged += OnBrowserAddressChanged;
            Controls.Add(browser);
        }
        private void OnBrowserAddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => Text = e.Address);
        }
    }
}
  [1]: http://ChromiumWebBrowser.AddressChanged%20Event
