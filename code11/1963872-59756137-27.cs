    /// <summary>
    /// The DataContext and binding source for the dialog Window. Implement this interface or the derived abstract <see cref="DialogViewModel"/> to transport data from the view to the view model via binding.
    /// </summary>
    /// <remarks>It is recommended to extend the abstract class <see cref="DialogViewModel"/> instead as this class already implemented the dialog data handling logic. Also use the <see cref="Dialog"/> attached behavior as it handles the view logic. Just bind <see cref="Dialog.DialogDataContextProperty"/> to an instance of <see cref="DialogViewModel"/> (or <see cref="IDialogViewModel"/>) and define a DataTemplate for each implementation of <see cref="DialogViewModel"/>.</remarks>
    public interface IDialogViewModel
    {
      /// <summary>
      /// The title of the dialog <c>Window</c>
      /// </summary>
      string Title { get; set; }
      /// <summary>
      /// The message for the dialog to show to the user.
      /// </summary>
      string Message { get; set; }
      /// <summary>
      /// The <see cref="BionicUtilities.Net.Dialog.DialogResult"/> of the user interaction.
      /// </summary>
      DialogResult DialogResult { get; set; }
      /// <summary>
      /// The asynchronous callback that is invoked during the dialog interaction. Use this callback as continuation of the interrupted flow, after the required data was collected by the dialog.
      /// </summary>
      /// <remarks>When using the abstract class <see cref="DialogViewModel"/> this delegate is invoked when invoking the <see cref="SendResponseAsyncCommand"/>. The parameter of this callback is the original <see cref="IDialogViewModel"/>. The <see cref="ResponseCallbackAsync"/> makes the dialog interaction fire-and-forget as the <see cref="IDialogViewModelProviderSource"/> doesn't need to wait for the  dialog to close and doesn't have to store a reference to the <see cref="IDialogViewModel"/>.</remarks>
      Func<IDialogViewModel, Task> ResponseCallbackAsync { get; set; }
      /// <summary>
      /// ICommand that can be bound to the buttons of the dialog. The command parameter is a <see cref="Net.Dialog.DialogResult"/>.
      /// </summary>
      /// <remarks>When using the abstract class <see cref="DialogViewModel"/> the <see cref="SendResponseAsyncCommand"/> sets the <see cref="DialogResult"/> property and invokes the <see cref="ResponseCallbackAsync"/> continuation callback. The parameter of this callback is the original <see cref="IDialogViewModel"/>. The <see cref="ResponseCallbackAsync"/> makes the dialog interaction fire-and-forget as the <see cref="IDialogViewModelProviderSource"/> doesn't need to wait for the  dialog to close and doesn't have to store a reference to the <see cref="IDialogViewModel"/>.</remarks>
      RelayCommand<DialogResult> SendResponseAsyncCommand { get; }
      /// <summary>
      /// The icon to display in the title bar of the Window
      /// </summary>
      ImageSource TitleBarIcon { get; set; }
      /// <summary>
      /// Event to signal that the interaction with the dialog is completed.
      /// </summary>
      /// <remarks>When extending the abstract class <see cref="DialogViewModel"/> (instead of the <see cref="IDialogViewModel"/> interface) together with the attached property <see cref="Dialog.DialogDataContextProperty"/> raising this event will notify the <see cref="Dialog"/> attached behavior class to close the Window.</remarks>
      event EventHandler InteractionCompleted;
    }
