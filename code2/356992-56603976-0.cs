    using System;
    using System.ComponentModel;
    
    namespace ConsoleApp10
    {
        class Program
        {
            static void Main(string[] args)
            {
                var p = new Program();
                p.Run();
            }
    
            private void Run()
            {
                // Create Poco
                var poco = new MyPoco(1, "MyOldName", 150);
                // Attach property changed event
                poco.PropertyChanged += PocoOnPropertyChanged;
                // Change data
                poco.Id = 10;
                poco.Name = "NewName";
                poco.Height = 170;
            }
    
            /// <summary>
            /// Property changed handler
            /// </summary>
            /// <param name="sender"></param>
            /// <param name="e"></param>
            private void PocoOnPropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                // Without casting 'e' is a standard PropertyChanged event
                if (Equals(e.PropertyName, nameof(MyPoco.Id)))
                {
                    Console.WriteLine($"'{nameof(MyPoco.Id)}' has changed, but we have no other data");
                }
    
                // New extended property changed event of type 'string'
                if (Equals(e.PropertyName, nameof(MyPoco.Name)))
                {
                    // Need to cast into type we know and are expecting
                    if (e is PropertyChangedExtendedEventArgs<string> extended)
                    {
                        Console.WriteLine(
                            $"'{nameof(MyPoco.Name)}' has changed, from '{extended.OldValue}' to '{extended.NewValue}'.");
                    }
                }
    
                // New extended property changed event of type 'double'
                if (Equals(e.PropertyName, nameof(MyPoco.Height)))
                {
                    // This cast will fail as the types are wrong
                    if (e is PropertyChangedExtendedEventArgs<string>)
                    {
                        // Should never hit here
                    }
                    // Cast into type we know and are expecting
                    if (e is PropertyChangedExtendedEventArgs<double> extended)
                    {
                        Console.WriteLine(
                            $"'{nameof(MyPoco.Height)}' has changed, from '{extended.OldValue}' to '{extended.NewValue}'.");
                    }
                }
            }
        }
    
        /// <summary>
        /// Example POCO
        /// </summary>
        public sealed class MyPoco : NotifyBase
        {
            private int _id;
            private string _name;
            private double _height;
    
            public MyPoco(int id, string name, double height)
            {
                _id = id;
                _name = name;
                _height = height;
            }
    
            public int Id
            {
                get => _id;
                set
                {
                    var old = _id;
                    _id = value;
                    OnPropertyChanged(old, value, nameof(Id));
                }
            }
    
            public string Name
            {
                get => _name;
                set
                {
                    var old = _name;
                    _name = value;
                    OnPropertyChanged(old, value, nameof(Name));
                }
            }
    
            public double Height
            {
                get => _height;
                set
                {
                    var old = _height;
                    _height = value;
                    OnPropertyChanged(old, value, nameof(Height));
                }
            }
        }
    
        /// <summary>
        /// Notifying base class
        /// </summary>
        public abstract class NotifyBase : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;
    
            protected virtual void OnPropertyChanged<T>(T oldValue, T newValue, string propertyName = null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedExtendedEventArgs<T>(oldValue, newValue, propertyName));
            }
        }
    
        /// <summary>
        /// Extended property changed
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public sealed class PropertyChangedExtendedEventArgs<T> : PropertyChangedEventArgs
        {
            public PropertyChangedExtendedEventArgs(T oldValue, T newValue, string propertyName)
                : base(propertyName)
            {
                OldValue = oldValue;
                NewValue = newValue;
            }
    
            public T OldValue { get; }
            public T NewValue { get; }
        }
    }
