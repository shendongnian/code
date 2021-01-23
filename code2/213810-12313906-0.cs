    We can use MDSDK in this type of problems like 
    
    using System;
     
     
     
    using System.Collections.Generic;
     
    using System.ComponentModel;
     
    using System.Data;
     
    using System.Drawing;
     
    using System.Text;
     
    using System.Windows.Forms;
     
     
     
    using PsionTeklogix.Peripherals;
     
     
     
    namespace EnumAdapters
     
    {
     
        public partial class Form1 : Form
     
        {
     
            public Form1()
     
            {
     
                InitializeComponent();
     
     
     
                System.Collections.ArrayList pList = null;
     
                string[] lStatistic = null;
     
     
     
                try
     
                {
     
                    pList = Peripherals.EnumerateAdapters();
     
                }
     
                catch (Exception ex)
     
                {
     
                    MessageBox.Show("failed with\r\n" + ex.Message, "EnumerateAdapters()");
     
                    this.Close();
     
                    return;
     
                }
     
     
     
                listBox1.Items.Clear();
     
                foreach (string AdapterName in pList)
     
                {
     
                    try
     
                    {
     
                        listBox1.Items.Add(AdapterName +
     
                            (Peripherals.IsAdapterPresent(AdapterName) ? " is present" : " is NOT present") +
     
                            (Peripherals.IsWirelessAdapter(AdapterName) ? " [wireless adapter] " : ""));
     
     
     
                        lStatistic = Peripherals.GetAdapterStatistics(AdapterName); // See Note 1
     
                        foreach (string StatInfo in lStatistic)
     
                        {
     
                            if (StatInfo.StartsWith("Local MAC Address"))
     
                            {
     
                                listBox1.Items.Add("» " + StatInfo);
     
                                break;
     
                             }
     
                        }
     
                    }
     
                    catch (Exception ex)
     
                    {
     
                        MessageBox.Show(ex.Message);
     
                        this.Close();
     
                        return;
     
                    }
     
                }
     
            }
     
        }
     
    }
