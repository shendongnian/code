	private event EventHandler FadeAnimationCompleted;
	private void OnFadeAnimationCompleted(object sender)
	{
		if (FadeAnimationCompleted != null)
		{
			FadeAnimationCompleted(sender, null);
		}
	}
