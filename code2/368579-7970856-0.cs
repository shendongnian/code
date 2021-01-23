    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.WindowsCE.Forms;
    using System.Runtime.InteropServices;
    namespace Test1 {
      public class Form1 : Form {
        [DllImport("coredll.dll")]
        public static extern bool SipShowIM(int dwFlag);
        InputPanel sip;
        public Form1() {
          InitializeComponent();
          sip = new InputPanel();
          sip.EnabledChanged += new EventHandler(SIP_EnabledChanged);
        }
        void SIP_EnabledChanged(object sender, EventArgs e) {
          if (sip.Enabled) {
            Console.WriteLine("Enabled");
          } else {
            Console.WriteLine("Disabled");
          }
        }
      }
    }
