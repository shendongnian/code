    class Program
    {
      static void Main(string[] args)
      {
        var instance = new TestPropertyChanged();
        instance.PropertyChanged += PropertyChanged;
        instance.RaiseEvent(nameof(INotifyPropertyChanged.PropertyChanged), new PropertyChangedEventArgs("Hi There from anywhere"));
        Console.ReadLine();
      }
      private static void PropertyChanged(object sender, PropertyChangedEventArgs e)
      {
        Console.WriteLine(e.PropertyName);
      }
    }
    public static class PropertyRaiser
    {
      private static readonly BindingFlags staticFlags = BindingFlags.Instance | BindingFlags.NonPublic;
      public static void RaiseEvent(this object instance, string eventName, EventArgs e)
      {
        var type = instance.GetType();
        var eventField = type.GetField(eventName, staticFlags);
        if (eventField == null)
          throw new Exception($"Event with name {eventName} could not be found.");
        var multicastDelegate = eventField.GetValue(instance) as MulticastDelegate;
        if (multicastDelegate == null)
          return;
        var invocationList = multicastDelegate.GetInvocationList();
        foreach (var invocationMethod in invocationList)
          invocationMethod.DynamicInvoke(new[] {instance, e});
      }
    }
    public class TestPropertyChanged : INotifyPropertyChanged
    {
      public event PropertyChangedEventHandler PropertyChanged;
    }
