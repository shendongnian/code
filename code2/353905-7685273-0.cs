    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Outlook = Microsoft.Office.Interop.Outlook;
    namespace WindowsFormsApplication1
    {
    public partial class Form1 : Form
    {
        public Form1()
    {
    InitializeComponent();
    }
        private void Form1_Load(object sender, EventArgs e)
       {
            Outlook.ContactItem contact;
            Outlook.Application app = new Outlook.Application();
            contact = (Outlook.ContactItem)app.Session.OpenSharedItem(@"C:\vv.vfc");
            MessageBox.Show(contact.FirstName);
        }
       }
     }
