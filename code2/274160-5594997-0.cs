        using System;
        using System.Collections.Generic;
        using System.ComponentModel;
        using System.Data;
        using System.Drawing;
        using System.Text;
        using System.Windows.Forms;
        using System.Data.OracleClient;
        using System.IO;
        
        namespace CrystalReportWithOracle
        {
            public partial class frmMain : Form
            {
                public frmMain()
                {
                    InitializeComponent();
                }
        
                private void frmMain_Load(object sender, EventArgs e)
                {
                    my_rpt objRpt;
                    // Creating object of our report.
                    objRpt = new my_rpt();
        
                    String ConnStr = "SERVER=mydb;USER ID=user1;PWD=user1";
        
                    OracleConnection myConnection = new OracleConnection(ConnStr);
        
                    String Query1 = "select a.PROJECT_ID,a.PROJECT_NAME,b.GROUP_NAME from 
                    tbl_project a,tbl_project_group b where a.group_code= b.group_code";
        
                    OracleDataAdapter adapter = new OracleDataAdapter(Query1, ConnStr);
        
                    DataSet Ds = new DataSet();
        
                    // here my_dt is the name of the DataTable which we 
                    // created in the designer view.
                    adapter.Fill(Ds, "my_dt");
        
                    if (Ds.Tables[0].Rows.Count == 0)
                    {
                        MessageBox.Show("No data Found", "CrystalReportWithOracle");
                        return;
                    }
        
                    // Setting data source of our report object
                    objRpt.SetDataSource(Ds);
        
                    CrystalDecisions.CrystalReports.Engine.TextObject root;
                    root = (CrystalDecisions.CrystalReports.Engine.TextObject)
                         objRpt.ReportDefinition.ReportObjects["txt_header"];
                    root.Text = "Sample Report By Using Data Table!!";
        
                    // Binding the crystalReportViewer with our report object. 
                    crystalReportViewer1.ReportSource = objRpt;
                }
            }
        }
