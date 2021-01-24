   public class WiFiStrength : IObservable<int>
   {
      private int _signalQuality;
      private int _ratingValue;
      private class Unsubscriber : IDisposable
      {
         private List<IObserver<int>> _observers;
         private readonly IObserver<int> _observer;
         public Unsubscriber(List<IObserver<int>> observers, IObserver<int> observer)
         {
            _observers = observers;
            _observer = observer;
         }
         public void Dispose()
         {
            if (_observers != null)
            {
               _observers.Remove(_observer);
               _observers = null;
            }
         }
      }
      private List<IObserver<int>> _observers = new List<IObserver<int>>();
      private void SetAndRaiseIfChanged(int newRating)
      {
         if (_ratingValue != newRating)
         {
            _ratingValue = newRating;
            foreach (var observer in _observers)
            {
               observer.OnNext(newRating);
            }
         }
      }
      private static WiFiStrength _sharedInstance;
      private static Task _updater;
      private static CancellationTokenSource cts;
      private static void UpdateStrength(WiFiStrength model, CancellationToken ct)
      {
         var rnd = new Random();
         while (!ct.IsCancellationRequested)
         {
            model.SignalQuality = rnd.Next(100);
            Thread.Sleep(1000);
         }
      }
      public static WiFiStrength SharedInstance()
      {
         if (_sharedInstance == null)
         {
            _sharedInstance = new WiFiStrength();
            cts = new CancellationTokenSource();
            _updater = new Task(() => UpdateStrength(_sharedInstance, cts.Token));
            _updater.Start();
         }
         return _sharedInstance;
      }
      public int SignalQuality
      {
         get => _signalQuality;
         set
         {
            _signalQuality = value;
            if (_signalQuality >= 80)
            {
               SetAndRaiseIfChanged(5);
            }
            else if (_signalQuality >= 60)
            {
               SetAndRaiseIfChanged(4);
            }
            else if (_signalQuality >= 40)
            {
               SetAndRaiseIfChanged(3);
            }
            else if (_signalQuality >= 20)
            {
               SetAndRaiseIfChanged(2);
            }
            else if (_signalQuality >= 1)
            {
               SetAndRaiseIfChanged(1);
            }
            else
            {
               SetAndRaiseIfChanged(0);
            }
         }
      }
      public int SignalRating => _ratingValue;
      public IDisposable Subscribe(IObserver<int> observer)
      {
         _observers.Add(observer);
         return new Unsubscriber(_observers, observer);
      }
   }
You attach it to your bound class:
   public class ViewModel1 : INotifyPropertyChanged
   {
      public string TextField { get; set; }
      public WiFiStrength WiFi { get; set; }
      private IObserver<int> _observer;
      private class WiFiObserver : IObserver<int>
      {
         private readonly ViewModel1 _parent;
         private readonly IDisposable _unsubscribe;
         public WiFiObserver(ViewModel1 parent, WiFiStrength observed)
         {
            _parent = parent;
            _unsubscribe = parent.WiFi.Subscribe(this);
         }
         public void OnNext(int value)
         {
            _parent.NotifyPropertyChanged("WiFi");
         }
         public void OnError(Exception error)
         {
            _unsubscribe.Dispose();
         }
         public void OnCompleted()
         {
            _unsubscribe.Dispose();
         }
      }
      public ViewModel1()
      {
         WiFi = WiFiStrength.SharedInstance();
         _observer = new WiFiObserver(this, WiFi);
      }
      public event PropertyChangedEventHandler PropertyChanged;
      private void NotifyPropertyChanged(string propertyName)
      {
         PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
   }
Your class looks for changes, and notifies the owning form if it does change.
Your XAML need only bind to the property like this:
         <Label Content="{Binding WiFi.SignalRating, Mode=OneWay}"/>
Use on as many forms as you like.
