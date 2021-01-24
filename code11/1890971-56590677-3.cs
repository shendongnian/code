    private void ToggleFullscreen(bool isFullscreen)
    {
        RunOnUiThread(() =>
        {
            if (isFullscreen)
            {
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                    SystemUiFlags.Fullscreen
                    | SystemUiFlags.HideNavigation
                    | SystemUiFlags.Immersive
                    | SystemUiFlags.ImmersiveSticky
                    | SystemUiFlags.LowProfile
                    | SystemUiFlags.LayoutStable
                    | SystemUiFlags.LayoutHideNavigation
                    | SystemUiFlags.LayoutFullscreen
                );
            }
            else
            {
                Window.DecorView.SystemUiVisibility = (StatusBarVisibility)(
                    SystemUiFlags.LayoutStable
                );
            }
        });
    }
