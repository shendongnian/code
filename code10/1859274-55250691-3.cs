    private void LaunchScreenSelection_Click(object sender, EventArgs e)
    {
        ss = new ScreenSelection(buttonData);
        // Tell the ScreenLocation instance that we are 
        // interested to know when new data is ready
        ss.DataReady += myDataLoader;
        ss.Show(this);
    }
    // The ScreenLocation instance above will call this handler when ready
    private void myDataLoader(ButtonData btn)
    {
         // Now you have your info from the ScreenLocation instance 
         // and you can add it to the datatable used to build the grid 
         DataTable dt = AllEventData.Tables["AllEventData"];
         dt.Rows.Add(btn.ID, btn.Name, btn.Rect);
    }
