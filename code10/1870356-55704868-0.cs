`
private bool enabled = true;
public new bool Enabled2 {
	get {...}
	set {...}
}
`
Then I modified the "setter" from the property with my new function:
`
public new bool Enabled2 {
			get { return enabled; }
			set {
				this.Enabled = enabled = pictureEdit1.Enabled = labelControl1.Enabled = value;
				if (pictureEdit1.Image != null && !enabled)
					pictureEdit1.Image = setImageDisabled(pictureEdit1.Image);
				else
                    //buttonImage is a property which saves the "normal" image
					pictureEdit1.Image = buttonImage;
                //without this, the Image doesn't update
				if (DesignMode)
					Invalidate();
			}
		}
`
And last but not least, my function "setImageDisabled":
`
	private Image setImageDisabled(Image image) {
			try {
				Image grayedImage = ToolStripRenderer.CreateDisabledImage(image);
				return grayedImage;
			} catch { return null; }
		}
`
The only reason why I want to override the "Enabled"-property is, that if a other developer use this UserControl, the picture should be grayed out if he disable the whole control.
