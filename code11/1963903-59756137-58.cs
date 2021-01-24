    public class Dialog : DependencyObject
    {
      #region DialogDataContext attached property
      public static readonly DependencyProperty DialogDataContextProperty = DependencyProperty.RegisterAttached(
        "DialogDataContext", typeof(DialogViewModel), typeof(Dialog), new PropertyMetadata(default(DialogViewModel), Dialog.OnDialogDataContextChanged));
      public static void SetDialogDataContext(DependencyObject attachingElement, DialogViewModel value) => attachingElement.SetValue(Dialog.DialogDataContextProperty, value);
      public static DialogViewModel GetDialogDataContext(DependencyObject attachingElement) => (DialogViewModel)attachingElement.GetValue(Dialog.DialogDataContextProperty);
      #endregion
      private static Dictionary<DialogViewModel, Window> ViewModelToDialogMap { get; }
      static Dialog()
      {
        Dialog.ViewModelToDialogMap = new Dictionary<DialogViewModel, Window>();
      }
      public static bool TryGetDialog(DialogViewModel viewModel, out Window dialog) => Dialog.ViewModelToDialogMap.TryGetValue(viewModel, out dialog);
      private static void OnDialogDataContextChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
      {
        if (e.NewValue is DialogViewModel newDialogViewModel && attachingElement is FrameworkElement frameworkElement)
        {
          if (frameworkElement.IsLoaded)
          {
            Dialog.Show(attachingElement, newDialogViewModel);
          }
          else
          {
            frameworkElement.Loaded += Dialog.ShowDialogOnAttachingElementLoaded;
          }
        }
      }
      private static void ShowDialogOnAttachingElementLoaded(object sender, RoutedEventArgs e)
      {
        if (sender is Window window
            && window.DataContext is DialogViewModel dialogViewModel)
        {
          window.ContentTemplate = window.TryFindResource(dialogViewModel.GetType()) as DataTemplate;
        }
      }
      private static void Show(DependencyObject attachingElement, DialogViewModel newDialogViewModel)
      {
        newDialogViewModel.InteractionCompleted += Dialog.CloseDialogOnInteractionCompleted;
        Window window = Dialog.Prepare(attachingElement, newDialogViewModel);
        window.Closed += Dialog.CleanUpOnDialogClosed;
        Dialog.ViewModelToDialogMap.Add(newDialogViewModel, window);
        window.Show();
      }
      private static Window Prepare(DependencyObject attachingElement, DialogViewModel newDialogViewModel)
      {
        var window = new Window
        {
          Icon = newDialogViewModel.TitleBarIcon,
          SizeToContent = SizeToContent.WidthAndHeight,
          WindowStartupLocation = WindowStartupLocation.CenterOwner,
          Topmost = true,
          Title = newDialogViewModel.Title,
          DataContext = newDialogViewModel,
          Content = newDialogViewModel,
          ContentTemplateSelector = Dialog.GetDataTemplateSelector(attachingElement),
          Style = Dialog.GetStyle(attachingElement)
        };
        if (attachingElement is Window parentWindow
            || Dialog.TryFindVisualParentElement(attachingElement, out parentWindow))
        {
          window.Owner = parentWindow;
        }
        return window;
      }
      private static bool TryFindVisualParentElement<TParent>(DependencyObject child, out TParent resultElement)
        where TParent : DependencyObject
      {
        resultElement = null;
        DependencyObject parentElement = VisualTreeHelper.GetParent(child);
        if (parentElement is TParent parent)
        {
          resultElement = parent;
          return true;
        }
        return Dialog.TryFindVisualParentElement(parentElement, out resultElement);
      }
      private static void CleanUpOnDialogClosed(object sender, EventArgs e)
      {
        var dialogViewModel = (sender as Window).DataContext as DialogViewModel;
        Dialog.ViewModelToDialogMap.Remove(dialogViewModel);
        dialogViewModel.InteractionCompleted -= Dialog.CloseDialogOnInteractionCompleted;
      }
      private static void CloseDialogOnInteractionCompleted(object sender, EventArgs e)
      {
        if (Dialog.ViewModelToDialogMap.TryGetValue(sender as DialogViewModel, out Window dialog))
        {
          dialog.Close();
        }
      }
    }
