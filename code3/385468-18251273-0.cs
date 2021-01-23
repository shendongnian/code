    public class FireOnPreviewButton : Button
    {
        #region Constructor
        public FireOnPreviewButton()
        {
            PreviewMouseLeftButtonDown += OnLeftMouseButtonDownPreview;
        }
        #endregion
        #region Event Handler
        private void OnLeftMouseButtonDownPreview(object sender, MouseButtonEventArgs e)
        {
            // Prevent the event from going further
            e.Handled = true;
            // Invoke a click event on the button
            var peer = new ButtonAutomationPeer(this);
            var invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            if (invokeProv != null) invokeProv.Invoke();
        }
        #endregion
    }
