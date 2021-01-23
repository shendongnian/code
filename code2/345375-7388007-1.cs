    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.IO;
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
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
                string workingFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string inputFile = Path.Combine(workingFolder, "Input.pdf");
                string outputFile = Path.Combine(workingFolder, "Output.pdf");
    
                PdfReader reader = new PdfReader(inputFile);
                using(FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write, FileShare.None)){
                    using (PdfStamper stamper = new PdfStamper(reader, fs))
                    {
                        Dictionary<String, String> info = reader.Info;
                        info.Add("Title", "Hello World stamped");
                        info.Add("Subject", "Hello World with changed metadata");
                        info.Add("Keywords", "iText in Action, PdfStamper");
                        info.Add("Creator", "Silly standalone example");
                        info.Add("Author", "Also Bruno Lowagie");
                        stamper.MoreInfo = info;
                        stamper.Close();
                    }
                }
    
                this.Close();
            }
        }
    }
