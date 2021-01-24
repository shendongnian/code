        /// <summary>
        /// List for storing references to the LinkLabels
        /// </summary>
        List<LinkLabel> m_LinkLabels = new List<LinkLabel>();
        /// <summary>
        /// Creates and places all the LinkLabels on the form
        /// </summary>
        private void CreateLinkLabels()
        {
            int startingX = 100;        // starting top left X coordinate for first link label
            int startingY = 100;        // starting top left Y coordinate for first link label
            int xOffset = 20;           // horizontal space between labels
            int yOffset = 20;           // vertical space between labels
            int labelsToCreate = 100;   // total number of labels to create
            int labelsPerRow = 10;      // number of labels in each row
            int labelWidth = 61;        // width of the labels
            int labelHeight = 13;       // height of the labels
            int labelsInCurrentRow = 0; // number of labels in the current row
            int x = startingY;          // current x coordinate
            int y = startingX;          // current y coordinate
            int tabIndexBase = 65;      // base number for tab indexing 
            for (int i = 0; i < labelsToCreate; i++)
            {
                // update coordinates for next row
                if (labelsInCurrentRow == labelsPerRow)
                {
                    x = startingX;
                    y += yOffset;
                    labelsInCurrentRow = 0;
                }
                else
                {
                    x += xOffset;
                    labelsInCurrentRow++;
                }
                // create the label
                LinkLabel ll = new LinkLabel()
                {
                    Name = "LinkLabel" + (i + 1), // +1 to correct zero based index
                    AutoSize = true,
                    Location = new System.Drawing.Point(x, y),
                    Size = new System.Drawing.Size(labelWidth, labelHeight),
                    TabIndex = tabIndexBase + i,
                    TabStop = true,
                    Text = "LinkLabel" + (i + 1) // +1 to correct zero based index
                };
                // add the label to the list
                m_LinkLabels.Add(ll);
            }
            // add all controls in the list to the form
            this.Controls.AddRange(m_LinkLabels.ToArray());
        }
