    private void LaunchScreenSelection_Click(object sender, EventArgs e)
    {
        ss = new ScreenSelection(buttonData);
        // Tell the ScreenLocation ss instance that we are 
        // interested to know when new data is ready
        ss.DataReady += myDataLoader;
        ss.Show(this);
    }
    // When the *ScreenLocation* instance will raise the event, 
    // we will be called here to handle the event
    private void myDataLoader(ButtonData btn)
    {
         // Now you have your info from the ScreenLocation instance 
         // and you can add it to the datatable used as datasource for the grid 
         DataTable dt = AllEventData.Tables["AllEventData"];
         dt.Rows.Add(btn.ID, btn.Name, btn.Rect);
    }
