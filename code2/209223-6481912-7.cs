	LazyProperty<Color> _eyeColor = new LazyProperty<Color>();
	public Color EyeColor
	{ 
		get 
		{
			return _eyeColor.Value(() => SomeCPUHungryMethod());
		} 
	}
