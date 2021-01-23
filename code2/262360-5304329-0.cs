    readonly Outlook.Application _outlookApp = new Outlook.Application();
    
    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        _outlookApp.ItemLoad += new Outlook.ApplicationEvents_11_ItemLoadEventHandler(test_ItemLoad);
    }
    
    void test_ItemLoad(object item)
    {
        if (item is Outlook.AppointmentItem)
        {
            var appt = item as Outlook.AppointmentItem;
            appt.PropertyChange += new ItemEvents_10_PropertyChangeEventHandler(appt_PropertyChange);
        }
    }
    
    void appt_PropertyChange(string name)
    {
        MessageBox.Show(string.Format("Name: {0}", name));
        xxx
    }
