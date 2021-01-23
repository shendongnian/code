    // Property grid events can’t be easily subscribed to however there is way to get at the KeyUp event without impacting operation. 
    // Note: The KeyDown event can be subscribed to in the same manner but the propertygrid is NOT updated with the key presses. 
    // This code is added in hope it may help someone else solve the problem. It is not offered as a total solution.
    // First define a class variable to indicate that events have been added.
    private bool m_bPropertyGridEventsAdded = false;
    public GlassInfoEntryPage(ViewBase view)
            : base(view)
        {
            InitializeComponent();
            // Subscribe to SelectedGridItemChanged
            m_PropertyGrid.SelectedGridItemChanged += M_PropertyGrid_SelectedGridItemChanged;
        }
    // Now define a SelectedGridItemChanged Event Handler
    private void M_PropertyGrid_SelectedGridItemChanged(object sender, SelectedGridItemChangedEventArgs e)
    {
            int nXlocation;
            int nYlocation;
            PropertyGrid oPropertyGrid;
            Control oControl;
            if (m_bPropertyGridEventsAdded == false)
            {
                oPropertyGrid = (PropertyGrid)sender;
                // Search the Property Grid for a PropertyGridView Control so events can be added to it
                for (nXlocation = 0; nXlocation < oPropertyGrid.Width; nXlocation += 10)
                {
                    for (nYlocation = 0; nYlocation < oPropertyGrid.Height; nYlocation += 10)
                    {
                        oControl = m_glassInfoPropertyGrid.GetChildAtPoint(new Point(nXlocation, nYlocation));
                        if (oControl != null)
                        {
                            if (oControl.GetType().ToString() == "System.Windows.Forms.PropertyGridInternal.PropertyGridView")
                            {
                                // Add Events here
                                oControl.Controls[1].KeyUp += MyCode_KeyUp;
                                m_bPropertyGridEventsAdded = true;
                                break;
                            }
                        }
                    }
                    if (m_bPropertyGridEventsAdded == true)
                    {
                        break;
                    }
                }
            }
        }        
    // Handle the events
    private void MyCode_KeyUp(object sender, KeyEventArgs e)
    {
    }
