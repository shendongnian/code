    public class SendSMSViewModel : INotifyPropertyChanged
    {
       string _text;
       public string Text 
       { 
          get { return _text; }
          set {
              // or allow it and implement IDataErrorInfo to give the user a nifty error message          
              if (value != null & value.Length > 160)
                  return;
              _text = value;
              OnPropertyChanged(vm => vm.Text);
              OnPropertyChanged(vm => vm.NumberOfCharactersRemaining);
         }
       }
       public string NumberOfCharactersRemaining 
       { 
           get { return Text == null ? 160 : 160 - Text.Length; }
       }
    }
