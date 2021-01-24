csharp
internal StreamEventsSlice GetStreamEventSlice(ResolvedEvent[] events = null, bool isEndOfStream = true)
{
    events = events ?? new ResolvedEvent[0];
    var type = typeof(StreamEventsSlice);
    var slice = (StreamEventsSlice) FormatterServices.GetUninitializedObject(type);
    type.GetField("Events").SetValue(slice, events);
    type.GetField("IsEndOfStream").SetValue(slice, isEndOfStream);
    return slice;
}
  [1]: https://stackoverflow.com/a/708976/6330878
  [2]: https://stackoverflow.com/a/2501740/6330878
