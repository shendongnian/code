    long bitMask = 0; // All uncheck
    for (int i = 0; i < chkServices.Items.Count; ++i) {
        if (chkServices.Items[i].Checked) {
            bitMask |= (1 << i);
        }
    }
    
    // Store bitMask to Database
