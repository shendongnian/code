    private void TextAlignment_combobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
	    if (EssayContents_richtextbox == null || EssayContents_richtextbox.Selection == null)
		{
		    // Handle me, or just
			return;
		}
		
		if (TextAlignment_combobox.SelectedIndex == 0)
		{
			EssayContents_richtextbox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty,  TextAlignment.Left);
		}
		if (TextAlignment_combobox.SelectedIndex == 1)
		{
			EssayContents_richtextbox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Center);
		}
		if (TextAlignment_combobox.SelectedIndex == 2)
		{
			EssayContents_richtextbox.Selection.ApplyPropertyValue(Paragraph.TextAlignmentProperty, TextAlignment.Right);
		}
	}
