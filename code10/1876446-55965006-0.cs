    private void ThisAddIn_Startup(object sender, System.EventArgs e)
            {
                //Create an instance of the user control
                _usr =new UserControl1();
                // Connect the user control and the custom task pane 
                _myCustomTaskPane = CustomTaskPanes.Add(_usr, "My Task Pane");
                _myCustomTaskPane.Visible = true;
            }
