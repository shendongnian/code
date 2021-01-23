    Name              value 
    lblname.text      frenchtype name 
     using System;
     using System.IO;
    using System.Linq;
    using System.Data;
    using System.Text;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.ComponentModel;
   
    public partial class Form1 : Form
    {
       public form1()
       {
        System.Threading.Thread.CurrentThread.CurrentUICulture = new
     System.Globalization.CultureInfo("fr-FR");
        getlanguagaefile();
        InitializeComponent();
       }
     // blah
     // blah
    private void getlanguagaefile()
    {
        if (label1.Text == "French")
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new
      System.Globalization.CultureInfo("fr-FR");
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Wait));
            resources.ApplyResources(this, "$this");
            applyResources(resources, this.Controls);
        }
      } 
