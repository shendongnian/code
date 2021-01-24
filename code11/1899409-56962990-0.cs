	IObservable<Unit> fileSystemWatcherChanges =
		Observable
			.Using(() =>
				new FileSystemWatcher(_path)
				{
					Filter = _file,
					EnableRaisingEvents = true
				},
				fsw =>
					Observable
						.FromEventPattern<FileSystemEventHandler, FileSystemEventArgs>(
							h => fsw.Changed += h, h => fsw.Changed -= h)
						.Select(x => Unit.Default));
