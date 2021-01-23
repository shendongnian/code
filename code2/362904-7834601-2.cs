        class TabView : UserControl
        {
             void DisplayData(Data data)
             {
                 if (this.InvokeRequired)
                 {
                     BeginInvoke(new Action<Data>(DisplayData), data);
                     return;
                 }
                 
                 // otherwise, display the data in some way
                 dataGrid.DataSource = data; ...
             }
        }
