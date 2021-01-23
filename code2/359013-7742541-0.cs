                         TextBox listBoxNewInput  = new TextBox();
                        //Initialize label's property
                        
                        listBoxNewInput.Multiline = true;
                        // Add vertical scroll bars to the TextBox control.
                        listBoxNewInput.ScrollBars = ScrollBars.Vertical;
                        // Allow the RETURN key in the TextBox control.
                        listBoxNewInput.AcceptsReturn = true;
                        // Allow the TAB key to be entered in the TextBox control.
                        listBoxNewInput.AcceptsTab = true;
                        // Set WordWrap to true to allow text to wrap to the next line.
                        listBoxNewInput.WordWrap = true;
                        
                        listBoxNewInput.Width = 315;
                        listBoxNewInput.Height = 150;
                        listBoxNewInput.DoubleClick += new EventHandler(listBoxNewInput_DoubleClick);
                       
                        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                        flowLayoutPanel1.Controls.Add(labelInput);
                        flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
                        flowLayoutPanel1.Controls.Add(list
