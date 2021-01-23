    using System;
    using System.IO;
    using System.Windows.Forms;
    // download at [http://xmlserialization.codeplex.com/]
    using System.Xml.Serialization;
    namespace test
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            [XmlRootSerializer("PrinterSettings")]
            public interface IPrinterSettings
            {
                bool PrintToFile { get; set; }
            }
    
            private static readonly string PrinterConfigurationFullName = Path.Combine(Application.StartupPath, "PrinterSettings.xml");
    
            private void Form1_Load(object sender, EventArgs e)
            {
                if (File.Exists(PrinterConfigurationFullName))
                {
                    XmlObjectSerializer.Load<IPrinterSettings>(File.ReadAllText(PrinterConfigurationFullName), printDialog1);
                }
            }
    
            private void Form1_FormClosed(object sender, FormClosedEventArgs e)
            {
                File.WriteAllText(PrinterConfigurationFullName, XmlObjectSerializer.Save<IPrinterSettings>(printDialog1));
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                if (printDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // do required stuff here...
                }
            }
        }
    }
