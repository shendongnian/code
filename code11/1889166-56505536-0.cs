private byte _level
public byte Level
{
	get { return _level; }
	set
	{
		if (value < 1 || value > 3)
		{
			_level = 1;
			throw new Exception("Level must be in 1 to 3. By default, it becomes 1");
		}
		else
		{
			_level = value;
		}
	}
}
