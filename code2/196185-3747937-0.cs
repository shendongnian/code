    for (int i = 0; i < tabs.TabCount; ++i) {
         if (tabs.GetTabRect(i).Contains(e.Location)) {
             //tabs.Controls[i]; // this is your tab
         }
    }
