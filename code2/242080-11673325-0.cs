		private void MoveListboxItems(int step, ListBox lb)
        {
			/* 'step' should be:
			 *   -1 for moving selected items up
			 *    1 for moving selected items down
			 * 'lb' is your ListBox
			 *   see examples how to call below this function
			/*
			try {
				// do only something when really an item is selected
				if (lb.SelectedIndex > -1) {
					// get some needed values - they change while we manipulate the listbox
					// but we need them as they was original
					IList SelectedItems = lb.SelectedItems;
					IList SelectedIndices = lb.SelectedIndices;
					
					// set some default values
					int selIndex = -1;
					int newIndex = -1;
					int selCount = SelectedItems.Count;
					int lc = 0;
					int mc = 0;
					string moveOldValue = string.Empty;
					string selectedItemValue = string.Empty;
					
					if (step == 1) {
						mc = selCount-1;
					} else {
						mc = lc;
					}
					// enter the loop through the selected items
					while (lc<selCount) {
						selectedItemValue = string.Empty;
						moveOldValue=string.Empty;
						
						try{
							// get the item that should get moved
							selectedItemValue = SelectedItems[mc].ToString();
							selIndex = Convert.ToInt32(SelectedIndices[mc]);
						} catch {selIndex = -1;}						
						// gen index for new place
						newIndex = selIndex+step;
						try {
							// get the old value from the place where the item get moved
							moveOldValue = lb.Items[newIndex].ToString();
						}catch{ /* do nothing */ }
						try {
							if (!String.IsNullOrEmpty(selectedItemValue)
							  && !String.IsNullOrEmpty(moveOldValue)
							  && selIndex!=-1
							  && newIndex!=-1
							  && !lb.SelectedIndices.Contains(newIndex)) {								
								// move selected item
								lb.Items.RemoveAt(newIndex);
								lb.Items.Insert(newIndex,selectedItemValue);
								// write old value back to the old place from selected item
								lb.Items.RemoveAt(selIndex);
								lb.Items.Insert(selIndex,moveOldValue);
								// hold the moved item selected
								lb.SetSelected(newIndex,true);
							}
						} catch{ /* do nothing */ }
						lc++;
						if (step == 1) {
							mc-=step;
						} else {
							mc = lc;
						}
					}
				}
			} catch { /* do nothing */ };
        }
		// examples how i call the function above
		void BtnLbUp_Click(object sender, EventArgs e)
		{
			MoveListboxItems(-1,this.lbMyList);
		}
		
		void BtnLbDown_Click(object sender, EventArgs e)
		{
			MoveListboxItems(1,this.lbMyList);
		}
