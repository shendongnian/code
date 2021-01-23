    using PsionTeklogix.Peripherals;
    namespace EnumAdapters
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
  
                ArrayList pList = null;
                string[] lStatistic = null;
                try
                {
                    pList = Peripherals.EnumerateAdapters();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("failed with\r\n" + ex.Message, "EnumerateAdapters()");
                    Close();
                    return;
                }
     
                listBox1.Items.Clear();
     
                foreach (string AdapterName in pList)
                {
                    try
                    {
                        listBox1.Items.Add(AdapterName + (Peripherals.IsAdapterPresent(AdapterName) ? " is present" : " is NOT present") + (Peripherals.IsWirelessAdapter(AdapterName) ? " [wireless adapter] " : ""));
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
                        Close();
                        return;
                    }
                }
            }
        }
    }
