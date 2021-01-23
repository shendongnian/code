        ///<summary>
        /// Flag to indicate the window is open - use to prevent opening this particular help window multiple times...
        ///</summary>
        public static bool IsOpen { get; private set; }
        ...
        ...
        ...
      private void HelpWindowLoaded(object sender, RoutedEventArgs e)
        {
            IsOpen = true;
        }
        private void HelpWindowUnloaded(object sender, RoutedEventArgs e)
        {
            IsOpen = false;
        }
