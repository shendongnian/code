	var anim = new DoubleAnimationUsingKeyFrames();
	anim.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = TimeSpan.FromSeconds(0), Value = 0 });
	anim.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = TimeSpan.FromSeconds(0.5), Value = -90 });
	anim.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = TimeSpan.FromSeconds(0.6), Value = -90 });
	anim.KeyFrames.Add(new EasingDoubleKeyFrame() { KeyTime = TimeSpan.FromSeconds(1), Value = 0 });
	Storyboard.SetTarget(anim, rectangle);
	Storyboard.SetTargetProperty(anim, new PropertyPath("Projection.RotationY"));
