    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Coke_Hold_Database
    {
        public partial class frmEnterTestResult : Form
        {
            Record_HoldData thisHold = new Record_HoldData();
            
    
            linqCokeDBDataContext db = new linqCokeDBDataContext();
    
            public frmEnterTestResult(Record_HoldData hold)
            {
                InitializeComponent();
                this.thisHold = hold;
    
                    
                //sample
                int palletSize = 96;
                int palletsOnHold = Math.Abs(thisHold.HoldQty / palletSize);
                int requiredSamples = palletsOnHold * 4;  
                               
    
                //create datagrid rows?
                for (short i = 0; i < requiredSamples; i++)
                {
                    dgTestResults.Rows.Add();
                }
    
                //fill the grid widths
                dgTestResults.Columns[0].FillWeight = 30;
                dgTestResults.Columns[1].FillWeight = 30;
                dgTestResults.Columns[2].FillWeight = 30;
                dgTestResults.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    
               
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //create a list that will store each row as an object
                List<Record_TestResult> testResultList = new List<Record_TestResult>();
                //create an object for every row
                foreach (DataGridViewRow item in dgTestResults.Rows)
                {
                    //create a new object 
                    Record_TestResult results = new Record_TestResult();
                    //set the details of the hold in the object
                    results.HoldID = thisHold.HoldID;
                    results.type = thisHold.NonConformingItem;
                    results.entryTime = DateTime.Now;
                    //traverse the grid and update the object values from user input
                    results.productTime = Convert.ToDateTime(item.Cells[0].Value);
                    results.result = Convert.ToDecimal(item.Cells[1].Value);
                    results.pass = Convert.ToBoolean(item.Cells[2].Value);
                    results.testedBy = 1002; //stub
    
                    //add the completed object to the list
                    testResultList.Add(results);
                }
    
                //add the list to what LINQ will submit and then submit
                db.Record_TestResults.InsertAllOnSubmit(testResultList);
                db.SubmitChanges();
            }
        }
    }
