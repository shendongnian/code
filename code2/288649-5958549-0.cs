<!-- -->
	private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		e.Cancel = true;
		DoubleAnimation anim = new DoubleAnimation(0, (Duration)TimeSpan.FromSeconds(1));
		anim.Completed += (s, _) => this.Close();
		this.BeginAnimation(UIElement.OpacityProperty, anim);
	}
