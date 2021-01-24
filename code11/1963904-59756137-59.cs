    public abstract class DialogViewModel : INotifyPropertyChanged
    {
      protected DialogViewModel(string message, string title) : this(message, title, (dialogViewModel) => Task.CompletedTask)
      {
      }
      protected DialogViewModel(string message, string title, Func<DialogViewModel, Task> sendResponseCallbackAsync) : this(message, title, null, sendResponseCallbackAsync)
      {
      }
      protected DialogViewModel(string message, string title, ImageSource titleBarIcon, Func<DialogViewModel, Task> sendResponseCallbackAsync)
      {
        this.ResponseCallbackAsync = sendResponseCallbackAsync;
        this.Message = message;
        this.Title = title;
        this.TitleBarIcon = titleBarIcon;
      }
      protected virtual async void ExecuteResponseCallback(object result)
      {
        this.DialogResult = (DialogResult) result;
        await this.ResponseCallbackAsync.Invoke(this).ConfigureAwait(false);
        OnInteractionCompleted();
      }
      
      private string title;   
      public string Title
      {
        get => this.title;
        set 
        { 
          this.title = value; 
          OnPropertyChanged();
        }
      }
      private string message;   
      public string Message
      {
        get => this.message;
        set 
        { 
          this.message = value; 
          OnPropertyChanged();
        }
      }
      private ImageSource titleBarIcon;
      public ImageSource TitleBarIcon
      {
        get => this.titleBarIcon;
        set
        {
          this.titleBarIcon = value;
          OnPropertyChanged();
        }
      }
      public RelayCommand SendResponseCommand => new RelayCommand(ExecuteResponseCallback, (param) => true);
      private DialogResult dialogResult;   
      public DialogResult DialogResult
      {
        get => this.dialogResult;
        set 
        { 
          this.dialogResult = value; 
          OnPropertyChanged();
        }
      }
      private Func<DialogViewModel, Task> responseCallbackAsync;   
      public Func<DialogViewModel, Task> ResponseCallbackAsync
      {
        get => this.responseCallbackAsync;
        set 
        { 
          this.responseCallbackAsync = value; 
          OnPropertyChanged();
        }
      }
      public event EventHandler InteractionCompleted;
      protected virtual void OnInteractionCompleted()
      {
        this.InteractionCompleted?.Invoke(this, EventArgs.Empty);
      }
      public event PropertyChangedEventHandler PropertyChanged;
      protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
      {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
      }
    }
    
