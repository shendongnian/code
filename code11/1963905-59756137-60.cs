    public class FileExistsDialogViewModel : DialogViewModel
    {
      public FileExistsDialogViewModel(string message, string title) : base(message, title)
      { 
      }
      public FileExistsDialogViewModel(string message, string title, Func<DialogViewModel, Task> sendResponseCallbackAsync) : base(message, title, sendResponseCallbackAsync)
      { 
      }
      public FileExistsDialogViewModel(string message, string title, ImageSource titleBarIcon, Func<DialogViewModel, Task> sendResponseCallbackAsync) : base(message, title, titleBarIcon, sendResponseCallbackAsync)
      { 
      }
    }
