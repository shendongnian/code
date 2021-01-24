cs
public class MyViewModel : INotifyPropertyChanged {
	//Backing field for IsAllowed
	private bool _isAllowed = true;
	/// <summary>
	/// Gets or sets the IsAllowed property.
	/// </summary>
	public bool IsAllowed {
		get => _isAllowed; set {
			if (_isAllowed != value) {
				_isAllowed = value;
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAllowed)));
			}
		}
	}
	//INotifyPropertyChanged
	public event PropertyChangedEventHandler PropertyChanged;
}
You can also look into the ```IValueCOnverter``` interface and XAML converters for other ways.
