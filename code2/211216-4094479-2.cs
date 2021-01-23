        [Dependency]
        public IThemeManager ThemeManager
        {
            get { return _themeManager; }
            set
            {
                if (_themeManager != value)
                {
                    _themeManager = value;
                    if (_themeManager != null && !DesignMode)
                    {
                        _headerPanelBackgroundImageBinding = themePanel.DataBindings.Add("BackgroundImage", ThemeManager, "CuurentTheme.Logo", false, DataSourceUpdateMode.Never);
                    }
                    else
                    {
                        // Reset to the default
                        this.DataBindings.Remove(_headerPanelBackgroundImageBinding);
                    }
                    Invalidate();
                }
            }
        }
