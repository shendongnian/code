    public class IconControl : DependencyObject
    {
      #region IconUri attached property
      public static readonly DependencyProperty IconUriProperty = DependencyProperty.RegisterAttached(
        "IconUri", typeof(ImageSource), typeof(IconControl), new PropertyMetadata(default(ImageSource)));
      public static void SetIconUri([NotNull] DependencyObject attachingElement, ImageSource value)
      {
        attachingElement.SetValue(IconControl.IconUriProperty, value);
      }
      public static ImageSource GetIconUri([NotNull] DependencyObject attachingElement) => (ImageSource) attachingElement.GetValue(IconControl.IconUriProperty);
      #endregion
      #region Label attached property
      public static readonly DependencyProperty LabelProperty = DependencyProperty.RegisterAttached(
        "Label", typeof(String), typeof(IconControl), new PropertyMetadata(default(String)));
      public static void SetLabel([NotNull] DependencyObject attachingElement, String value)
      {
        attachingElement.SetValue(IconControl.LabelProperty, value);
      }
      public static String GetLabel([NotNull] DependencyObject attachingElement) => (String) attachingElement.GetValue(IconControl.LabelProperty);
      #endregion
    }
