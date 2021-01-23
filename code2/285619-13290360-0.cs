    	private TextRange ExtendSelection(LogicalDirection direction)
	{
		TextRange tr = new TextRange(CaretPosition, CaretPosition.GetInsertionPosition(direction));
		bool found = false;
		while (!found)
		{
			if (tr == null)
			{
				break;
			}
			else
			{
				// If we are not at the end of the document (or at the beginning)
				TextPointer next = null;
				if (LogicalDirection.Forward.CompareTo(direction) == 0 && tr.End.CompareTo(Document.ContentEnd) == -1)
				{
					next = tr.End.GetNextInsertionPosition(direction);	
				}
				else if (LogicalDirection.Backward.CompareTo(direction) == 0 && tr.Start.CompareTo(Document.ContentStart) == 1)
				{
					next = tr.Start.GetNextInsertionPosition(direction);
				}
				// Be careful with boundaries!
				if (next != null)
				{
					TextRange trNext = new TextRange(CaretPosition, next);
					char[] text = trNext.Text.ToCharArray();
					for (int i = 0; i < text.Length; i++)
					{
						if (Char.IsWhiteSpace(text[i]) || Char.IsSeparator(text[i]))
						{
							found = true;
							break;
						}
					}
					if (!found)
					{
						tr = trNext;
					}
				}
				else
				{
					break;
				}
			}
		}
		return tr;
	}
	private void MyRichTextBox_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
	{
		TextRange left = ExtendSelection(LogicalDirection.Backward);
		TextRange right = ExtendSelection(LogicalDirection.Forward);
		if (!left.IsEmpty && !right.IsEmpty)
		{
			Selection.Select(left.Start, right.End);
			Console.WriteLine("Highlight: '" + Selection.Text + "'");
		}
	}
