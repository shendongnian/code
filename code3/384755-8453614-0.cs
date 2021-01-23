    /// <summary>
    /// Andy On WPF: DropDownButtons in WPF
    /// http://andyonwpf.blogspot.com/2006/10/dropdownbuttons-in-wpf.html
    /// </summary>
    public class DropDownButton : ToggleButton
    {
        #region Members
        public enum Placement { Bottom, Right }
        #endregion
        #region Properties
        #region DropDownPlacement
        /// <summary>
        /// DropDown placement.
        /// </summary>
        public Placement DropDownPlacement
        {
            get { return (Placement)GetValue(DropDownPlacementProperty); }
            set { SetValue(DropDownPlacementProperty, value); }
        }
        /// <summary>
        /// DropDown placement (Dependency Property).
        /// </summary>
        public static readonly DependencyProperty DropDownPlacementProperty =
            DependencyProperty.Register("DropDownPlacement", typeof(Placement),
            typeof(DropDownButton), new UIPropertyMetadata(null));
        #endregion
        #region DropDown
        /// <summary>
        /// DropDown property.
        /// </summary>
        public ContextMenu DropDown
        {
            get { return (ContextMenu)GetValue(DropDownProperty); }
            set { SetValue(DropDownProperty, value); }
        }
        /// <summary>
        /// DropDown property (Dependency property).
        /// </summary>
        public static readonly DependencyProperty DropDownProperty =
            DependencyProperty.Register("DropDown", typeof(ContextMenu),
            typeof(DropDownButton), new PropertyMetadata(null, OnDropDownChanged));
        #endregion
        #endregion
        #region Events
        private static void OnDropDownChanged(DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            ((DropDownButton)sender).OnDropDownChanged(e);
        }
        void OnDropDownChanged(DependencyPropertyChangedEventArgs e)
        {
            if (DropDown != null)
            {
                DropDown.PlacementTarget = this;
                switch (DropDownPlacement)
                {
                    default:
                    case Placement.Bottom:
                        DropDown.Placement = PlacementMode.Bottom;
                        break;
                    case Placement.Right:
                        DropDown.Placement = PlacementMode.Right;
                        break;
                }
                this.Checked +=
                    new RoutedEventHandler((a, b) => { DropDown.IsOpen = true; });
                this.Unchecked +=
                    new RoutedEventHandler((a, b) => { DropDown.IsOpen = false; });
                DropDown.Closed +=
                    new RoutedEventHandler((a, b) => { this.IsChecked = false; });
            }
        }
        #endregion
    }
