    /// <summary>
    /// Adjusts the position of the Outlook overflow grip.
    /// </summary>
    public void AdjustOutlookViewOverflowGrip()
    {
    	if (ViewMode == PageViewMode.Outlook && SelectedPage != null)
    	{
    		// Fix rendering bug by hiding RadPageViewPage's that are not currently selected
    		foreach (RadPageViewPage page in Pages)
    		{
    			if (page == SelectedPage)
    			{
    				page.Show();
    			}
    			else
    			{
    				page.Hide();
    			}
    		}
    	
    		// Elements from control
    		RadPageViewOutlookElement outlookElement = (RadPageViewOutlookElement)ViewElement;
    		OverflowItemsContainer overflowItemsContainer = (OverflowItemsContainer)GetChildAt(0).GetChildAt(4);
    
    		// Selected page and item heights
    		int selectedPageMinHeight = (SelectedPage.MinimumSize.Height > ContentMinimumHeight ? SelectedPage.MinimumSize.Height : contentMinimumHeight);
    		int pageSelectorHeight = SelectedPage.Item.Size.Height;
    
    		// Show or hide items
    		if (pageSelectorHeight > 0 && selectedPageMinHeight > 0)
    		{
    			// Calculate content area height
    			int contentAreaHeight =                 
    				(
    					Size.Height -
    					(
    						from element in ((RadPageViewOutlookElement)ViewElement).Children
    						where
    						(
    							element.Visibility != ElementVisibility.Collapsed
    							&&
    							(
    								element is RadPageViewLabelElement
    								|| element is OutlookViewOverflowGrip
    								|| element is RadPageViewOutlookItem
    								|| element is OverflowItemsContainer
    							)
    						)
    						select element.Size.Height + element.Margin.Vertical
    					)
    					.Sum()
    				);
    
    			if (contentAreaHeight < selectedPageMinHeight)
    			{
    				// Factor in OverflowItemsContainer height if it's currently collapsed
    				int overflowItemsHeight = (overflowItemsContainer.Visibility == ElementVisibility.Collapsed ? overflowItemsContainer.Size.Height : 0);
    
    				// Not enough space available... hide items
    				int hide = (int)Math.Ceiling((double)(selectedPageMinHeight - contentAreaHeight + overflowItemsHeight) / (double)pageSelectorHeight);
    				if (hide > 0)
    				{
    					outlookElement.HideItems(hide);
    				}
    			}
    			else if (contentAreaHeight >= (selectedPageMinHeight + pageSelectorHeight))
    			{
    				// More space available... show items
    				int show = (int)Math.Floor((double)(contentAreaHeight - selectedPageMinHeight) / (double)pageSelectorHeight);
    				if (show > 0)
    				{
    					outlookElement.ShowItems(show);
    				}
    			}
    		}
    
    		// Set overflow container visiblity
    		overflowItemsContainer.Visibility = (outlookElement.GetHiddenItems().Length > 0 ? ElementVisibility.Visible : ElementVisibility.Collapsed);
    	}
    }
