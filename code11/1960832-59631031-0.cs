public class Query
{
    private ObservableCollection<NameParameter> _parameters = new ObservableCollection<NameParameter>();
    public IEnumerable<NameParameter> Parameters => _parameters.AsEnumerable();
    public void AddParameter()
    {
        _parameters.Add(new NameParameter());
    }
    public void SubscribeParametersCollectionChanges(NotifyCollectionChangedEventHandler handler)
    {
        _parameters.CollectionChanged += handler;
    }
}
public class ExecuteQuery
{
    public ExecuteQuery()
    {
        PropertyChanged += ExecuteQuery_PropertyChanged;
    }
    private void ExecuteQuery_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Query))
            OnQuerySelection();
    }
    private Query _query;
    public Query Query
    {
        get => _query;
        set => SetProperty(ref _query, value);
    }
    private ObservableCollection<KeyValueParameter> _parameters = new ObservableCollection<KeyValueParameter>();
    public IEnumerable<KeyValueParameter> Parameters => _parameters.AsEnumerable();
    private void OnQuerySelection()
    {
        // subscribe to NamedParameters collection changed events
        DataElement?.SubscribeParametersCollectionChanges(Parameters_CollectionChanged);
        // calling this method explicitly so that if there are already Parameters in Source, bring them right away
        Parameters_CollectionChanged(this, null);
    }
    private void Parameters_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        // subscribe to each object property changed events in NamedParameters 
        foreach (var namedParameter in Query.Parameters)
            if (namedParameter is INotifyPropertyChanged npc)
                npc.PropertyChanged += Parameters_PropertyChanged;
        // copying parameters from source to target
        _parameters = new ObservableCollection<KeyValueParameter>(
            Query.Parameters.Select(x => new KeyValueParameter(x.Name)));
        // raising event to notify UI for this change
        RaisePropertyChanged(nameof(Parameters));
    }
    private void Parameters_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Name))
        {
            var namedParameter = Query.Parameters.ToList();
            for (var i = 0; i < namedParameter.Count; i++)
                _parameters[i].Name = namedParameter[i].Name;
        }
    }
}
