    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Windows.Documents;
    
    namespace RtfTest
    {
        class Program
        {
            [STAThread]
            static void Main(string[] args)
            {
                DoRead();
            }
    
            private static void DoRead()
            {
                // Create OpenFileDialog 
                OpenFileDialog dlg = new OpenFileDialog();
    
                // Set filter for file extension and default file extension 
                dlg.DefaultExt = ".rtf";
                dlg.Filter = "RichText Files (*.rtf)|*.rtf";
    
                // Display OpenFileDialog by calling ShowDialog method 
                var result = dlg.ShowDialog();
                try
                {
                    if (result == DialogResult.OK)
                    {
                        // Open document 
                        string filename = dlg.FileName;
                        FlowDocument flowDocument = new FlowDocument();
                        TextRange textRange = new TextRange(flowDocument.ContentStart, flowDocument.ContentEnd);
    
                        using (FileStream fileStream = File.Open(filename, FileMode.Open, FileAccess.Read, FileShare.Read))
                        {
                            textRange.Load(fileStream, DataFormats.Rtf);
                        }
    
                    }
                }
                catch (Exception)
                {
                    
                    throw;
                }
    
                
            }
        }
    }
