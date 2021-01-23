                _hotKey0 = new HotKey(Key.F9, KeyModifier.Shift | KeyModifier.Win, OnHotKeyHandler);
...
            // ******************************************************************
        private void OnHotKeyHandler(HotKey hotKey)
        {
            SystemHelper.SetScreenSaverRunning();
        }
