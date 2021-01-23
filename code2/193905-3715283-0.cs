    ToolStripControlHost tsHost = new ToolStripControlHost(dataGridView1);
    tsHost.AutoSize = false; // Set AutoSize property to false.
    tsHost.Height = 30;      // then set Height property value.
    contextMenuStrip1.Items.Clear();
    contextMenuStrip1.Items.Add(tsHost);
