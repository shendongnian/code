    void Item_ToolTipOpening(object sender, ToolTipEventArgs e)
		{
			if (sender as FrameworkElement == null)
				return;
			ToolTip tooltip = (ToolTip) FindResource("MailItemToolTip");
			if ((sender as FrameworkElement).DataContext is LinkItem)
				tooltip.DataContext = ((sender as FrameworkElement).DataContext as LinkItem).ParentItem as MailItem;
			else if ((sender as FrameworkElement).DataContext is AttachmentItem)
				tooltip.DataContext = ((sender as FrameworkElement).DataContext as AttachmentItem).ParentItem as MailItem;
			(sender as FrameworkElement).ToolTip = tooltip;
		}
