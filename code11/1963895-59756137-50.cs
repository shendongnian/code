    public class Dialog : DependencyObject
    {
      #region DialogDataContext attached property
      public static readonly DependencyProperty DialogDataContextProperty = DependencyProperty.RegisterAttached(
        "DialogDataContext", typeof(IDialogViewModel), typeof(Dialog), new PropertyMetadata(default(IDialogViewModel), Dialog.OnDialogDataContextChanged));
      public static void SetDialogDataContext([NotNull] DependencyObject attachingElement, IDialogViewModel value) => attachingElement.SetValue(Dialog.DialogDataContextProperty, value);
      public static IDialogViewModel GetDialogDataContext([NotNull] DependencyObject attachingElement) => (IDialogViewModel)attachingElement.GetValue(Dialog.DialogDataContextProperty);
      #endregion
      #region DataTemplateSelector attached property
      public static readonly DependencyProperty DataTemplateSelectorProperty = DependencyProperty.RegisterAttached(
        "DataTemplateSelector", typeof(DataTemplateSelector), typeof(Dialog), new PropertyMetadata(default(DataTemplateSelector)));
      public static void SetDataTemplateSelector([NotNull] DependencyObject attachingElement, DataTemplateSelector value) => attachingElement.SetValue(Dialog.DataTemplateSelectorProperty, value);
      public static DataTemplateSelector GetDataTemplateSelector([NotNull] DependencyObject attachingElement) => (DataTemplateSelector)attachingElement.GetValue(Dialog.DataTemplateSelectorProperty);
      #endregion
      #region Style attached property
      /// <summary>
      /// The attached Style property which holds the <see cref="Style"/> which should apply to the dialog. <see cref="Style.TargetType"/> must be <see cref="Window"/>.
      /// </summary>
      public static readonly DependencyProperty StyleProperty = DependencyProperty.RegisterAttached(
        "Style", typeof(Style), typeof(Dialog), new PropertyMetadata(default(Style)));
      public static void SetStyle([NotNull] DependencyObject attachingElement, Style value) => attachingElement.SetValue(Dialog.StyleProperty, value);
      public static Style GetStyle([NotNull] DependencyObject attachingElement) => (Style)attachingElement.GetValue(Dialog.StyleProperty);
      #endregion
      private static Dictionary<IDialogViewModel, Window> ViewModelToDialogMap { get; }
      static Dialog()
      {
        Dialog.ViewModelToDialogMap = new Dictionary<IDialogViewModel, Window>();
      }
      public static bool TryGetDialog(IDialogViewModel viewModel, out Window dialog) => Dialog.ViewModelToDialogMap.TryGetValue(viewModel, out dialog);
      private static void OnDialogDataContextChanged(DependencyObject attachingElement, DependencyPropertyChangedEventArgs e)
      {
        if (e.NewValue is IDialogViewModel newDialogViewModel && attachingElement is FrameworkElement frameworkElement)
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
            && window.DataContext is IDialogViewModel dialogViewModel)
        {
          window.ContentTemplate = window.TryFindResource(dialogViewModel.GetType()) as DataTemplate;
        }
      }
      private static void Show(DependencyObject attachingElement, IDialogViewModel newDialogViewModel)
      {
        newDialogViewModel.InteractionCompleted += Dialog.CloseDialogOnInteractionCompleted;
        Window window = Dialog.Prepare(attachingElement, newDialogViewModel);
        window.Closed += Dialog.CleanUpOnDialogClosed;
        Dialog.ViewModelToDialogMap.Add(newDialogViewModel, window);
        window.Show();
      }
      private static Window Prepare(DependencyObject attachingElement, IDialogViewModel newDialogViewModel)
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
            || attachingElement.TryFindVisualParentElement(out parentWindow))
        {
          window.Owner = parentWindow;
        }
        return window;
      }
      private static void CleanUpOnDialogClosed(object sender, EventArgs e)
      {
        var dialogViewModel = (sender as Window).DataContext as IDialogViewModel;
        Dialog.ViewModelToDialogMap.Remove(dialogViewModel);
        dialogViewModel.InteractionCompleted -= Dialog.CloseDialogOnInteractionCompleted;
      }
      private static void CloseDialogOnInteractionCompleted(object sender, EventArgs e)
      {
        if (Dialog.ViewModelToDialogMap.TryGetValue(sender as IDialogViewModel, out Window dialog))
        {
          dialog.Close();
        }
      }
    }
