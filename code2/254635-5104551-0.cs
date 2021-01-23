    //To generate PDF dynamically 
    using System;
        using System.Windows.Forms;
        using CrystalDecisions.CrystalReports.Engine;
        using CrystalDecisions.Shared;
        
        namespace WindowsApplication1
        {
            public partial class Form1 : Form
            {
                ReportDocument cryRpt;
        
                public Form1()
                {
                    InitializeComponent();
                }
        
                private void button1_Click(object sender, EventArgs e)
                {
                    cryRpt = new ReportDocument();
                    cryRpt.Load(PUT CRYSTAL REPORT PATH HERE\\CrystalReport1.rpt");
                    crystalReportViewer1.ReportSource = cryRpt;
                    crystalReportViewer1.Refresh(); 
                }
        
                private void button2_Click(object sender, EventArgs e)
                {
                    try
                    {
                        ExportOptions CrExportOptions ;
                        DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                        PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                        CrDiskFileDestinationOptions.DiskFileName = "c:\\csharp.net-informations.pdf";
                        CrExportOptions = cryRpt.ExportOptions;
                        {
                            CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                            CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                            CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                            CrExportOptions.FormatOptions = CrFormatTypeOptions;
                        }
                        cryRpt.Export();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
        }
