		static public void ReplaceControl(Control ToReplace, Form ReplaceWith) {
			ReplaceWith.TopLevel=false;
			ReplaceWith.FormBorderStyle=FormBorderStyle.None;
			ReplaceWith.Show();
			ReplaceWith.Anchor=ToReplace.Anchor;
			ReplaceWith.Dock=ToReplace.Dock;
			ReplaceWith.Font=ToReplace.Font;
			ReplaceWith.Size=ToReplace.Size;
			ReplaceWith.Location=ToReplace.Location;
			ToReplace.Parent.Controls.Add(ReplaceWith);
			ToReplace.Visible=false;
		}
