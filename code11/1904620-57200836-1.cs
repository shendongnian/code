csharp
[ObservableAsProperty] 
public bool Easy { get; }
public ObservableCollection<string> Difficulties { get; }
public Song()
{
    Difficulties = new ObservableCollection<string>();
    // Observe any changes in the observable collection.
    // Note that the property has no public setters, so we 
    // assume the collection is mutated by using the Add(), 
    // Delete(), Clear() and other similar methods.
    this.Difficulties
        // Convert the collection to a stream of chunks,
        // so we have IObservable<IChangeSet<TKey, TValue>>
        // type also known as the DynamicData monad.
        .ToObservableChangeSet(x => x)
        // Each time the collection changes, we get
        // all updated items at once.
        .ToCollection()
        // If the collection isn't empty, we access the
        // first element and check if it is an empty string.
        .Select(items => 
            items.Any() &&
            !string.IsNullOrWhiteSpace(items.First()))
        // Then, we convert the boolean value to the
        // property. When the first string in the
        // collection isn't empty, Easy will be set
        // to True, otherwise to False.
        .ToPropertyEx(this, x => x.Easy);
}
Note, that if you are using immutable data sets, for example somewhat like this:
csharp
[Reactive] public IEnumerable<string> Difficulties { get; set; }
and that data set is updated only through its public setter, then you should use the `WhenAnyValue` extension method here, as the collection declared as `IEnumerable<string>` isn't observable:
csharp
this.WhenAnyValue(x => x.Difficulties)
    .Select(items => 
        items.Any() &&
        !string.IsNullOrWhiteSpace(items.First()))
    .ToPropertyEx(this, x => x.Easy);
