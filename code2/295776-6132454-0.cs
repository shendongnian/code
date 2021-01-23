	private FileSystemEventHandler _eventBackingField;
	public event FileSystemEventHandler MyFileSystemEvent
	{
		add
		{
			_eventBackingField =
				(FileSystemEventHandler)Delegate.Combine(_eventBackingField, value);
		}
		remove
		{
			_eventBackingField =
				(FileSystemEventHandler)Delegate.Remove(_eventBackingField, value);
		}
	}
