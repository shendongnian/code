    using System;                                                              
    using System.Collections.Generic;                                          
    using System.ComponentModel;                                                
    using System.Data; System.Drawing;                                         
    using System.Text; System.Windows.Forms;                                   
    using System.Management;                                                   
    using System.Management.Instrumentation;                                    
                                                                           
    public partial class frmPrintDisplay : Form                                 
    {                                                                           
     public frmPrintDisplay()                                               
     {                                                                      
          InitializeComponent();                                            
     }                                                                      
                                                                            
     private void cmdGetPrinters_Click(object sender, EventArgs e)          
     {                                                                      
         ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Printer");
                                                                            
         ManagementObjectSearcher mo = new ManagementObjectSearcher(query); 
                                                                            
         ManagementObjectCollection printers = mo.Get();                    
                                                                            
        foreach (ManagementObject printer in printers)                      
        {                                                                  
            PropertyDataCollection printerProperties = printer.Properties;  
            string printerPath = printer.Path.ToString() ;                  
            PropertyDataCollection.PropertyDataEnumerator test =            
                printer.Properties.GetEnumerator();                         
                                                                            
            while(! (test.MoveNext()== false ))                             
            {                                                               
                lstPrinters.Items.Add(                                      
                    new ListViewItem( new string[]                          
                    {                                                       
                        test.Current.Name,                                  
                        (                                                  
                            (test.Current.Value == null) ?                  
                            "n/a" : test.Current.Value.ToString()           
                        )                                                   
                    })                                                      
                );                                                         
             }                                                               
          }                                                                   
        }                                                                       
      } 
