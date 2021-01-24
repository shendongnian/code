    public class FileExistsDialogViewModel : DialogViewModel
    {
      public FileExistsDialogViewModel(string message, string title) : base(message, title)
      { 
      }
      public FileExistsDialogViewModel(string message, string title, Func<IDialogViewModel, Task> sendResponseCallbackAsync) : base(message, title, sendResponseCallbackAsync)
      { 
      }
      public FileExistsDialogViewModel(string message, string title, ImageSource titleBarIcon, Func<IDialogViewModel, Task> sendResponseCallbackAsync) : base(message, title, titleBarIcon, sendResponseCallbackAsync)
      { 
      }
    }
