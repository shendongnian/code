        private CustomTaskPane tsPane;
        private int Wn;
        private Dictionary<string, int> dict;
        private void tsFinStRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            // Create a dictionary of indexes
            dict = new Dictionary<string, int>();
        }
        // Données
        private tsDataControl setDataPane()
        {
            // Initialize the window ID and pane name
            Wn = Globals.ThisAddIn.Application.Hwnd;
            string paneName = "Data" + Wn.ToString();
            // Check if the CTP already exists and create it otherwise
            if (!dict.ContainsKey(paneName))
            {
                tsPane = Globals.ThisAddIn.CustomTaskPanes.Add(new tsDataControl(), paneName);
                dict.Add(paneName, Globals.ThisAddIn.CustomTaskPanes.Count - 1);
            }
            else
            {
                tsPane = Globals.ThisAddIn.CustomTaskPanes[dict[paneName]];
            }
            // Get the tab control
            tsDataControl control = tsPane.Control as tsDataControl;
            if (!tsPane.Visible)
            {
                tsPane.Width = 320;
                tsPane.Visible = true;
            }
            return control;
        }
        // Etats
        private tsStControl setStPane()
        {
            // Initialize the window ID and pane name
            Wn = Globals.ThisAddIn.Application.Hwnd;
            string paneName = "Statement" + Wn.ToString();
            // Check if the CTP already exists and create it otherwise
            if (!dict.ContainsKey(paneName))
            {
                tsPane = Globals.ThisAddIn.CustomTaskPanes.Add(new tsStControl(), "Statement");
                dict.Add(paneName, Globals.ThisAddIn.CustomTaskPanes.Count - 1);
            }
            else
            {
                tsPane = Globals.ThisAddIn.CustomTaskPanes[dict[paneName]];
            }
            // Get the tab control
            tsStControl control = tsPane.Control as tsStControl;
            // Display the pane
            if (!tsPane.Visible)
            {
                tsPane.Width = 320;
                tsPane.Visible = true;
            }
            
            return control;
        }
        // Publications
        private tsPubControl setPubPane()
        {
            // Initialize the window ID and pane name
            Wn = Globals.ThisAddIn.Application.Hwnd;
            string paneName = "Publishing" + Wn.ToString();
            // Check if the CTP already exists and create it otherwise
            if (!dict.ContainsKey(paneName))
            {
                tsPane = Globals.ThisAddIn.CustomTaskPanes.Add(new tsPubControl(), paneName);
                dict.Add(paneName, Globals.ThisAddIn.CustomTaskPanes.Count - 1);
            }
            else
            {
                tsPane = Globals.ThisAddIn.CustomTaskPanes[dict[paneName]];
            }
            // Get the tab control  
            tsPubControl control = tsPane.Control as tsPubControl;
            // Display the pane
            if (!tsPane.Visible)
            {
                tsPane.Width = 320;
                tsPane.Visible = true;
            }
            return control;
        }
