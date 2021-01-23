using System;
using System.ComponentModel;
namespace ClassLibrary1
{
	public class Source : INotifyPropertyChanged
	{
		private String _Description;
		public String Description
		{
			get { return _Description; }
			set
			{
				if (_Description == value)
					return;
				_Description = value;
				OnPropertyChanged("Description");
			}
		}
		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = this.PropertyChanged;
			if (handler != null)
			{
				var e = new PropertyChangedEventArgs(propertyName);
				handler(this, e);
			}
		}
	}
}
</pre>
