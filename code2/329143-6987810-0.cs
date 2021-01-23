	//The property & field used for binding and editing
	private readonly ObservableCollection<GPASemestre> _ObservableSemestre = new ObservableCollection<GPASemestre>();
	public ObservableCollection<GPASemestre> ObservableSemestre { get { return _ObservableSemestre; } }
	//The property used for serialisation/deserialisation
	public GPASemestre[] Semestre
	{
		get
		{
			return ObservableSemestre.ToArray();
		}
		set
		{
			ObservableSemestre.Clear();
			foreach (var item in value)
			{
				ObservableSemestre.Add(item);
			}
		}
	}
