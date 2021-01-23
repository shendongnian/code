        private void setSplitterLeftPanelCollapsedState(bool collapse)
        {
            splitContainer1.SuspendLayout();
            // Collapse the left panel
            if (collapse)
            {
                if (!splitContainer1.Panel1Collapsed)
                {
                    // restoring the panel in the end to apply layout changes
                    buttonOpenPanel1.Text = ">";
                    splitContainer1.Panel1Collapsed = true;
                }
            }
            // Open the left panel
            else
            {
                if (splitContainer1.Panel1Collapsed)
                {
                    // collapsing the panel in the end to apply layout changes
                    buttonOpenPanel1.Text = "<";
                    splitContainer1.Panel1Collapsed = false;
                }
            }
            splitContainer1.ResumeLayout();
            comboBoxSearchText.Focus();
        }
