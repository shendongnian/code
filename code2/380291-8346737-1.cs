     int x = _manager.ActiveBrowser.Window.Location.X + _config.Positionals["SavePdf"].X;
                    int y = _manager.ActiveBrowser.Window.Location.Y + _config.Positionals["SavePdf"].Y;
                    if (!_manager.ActiveBrowser.Window.IsVisible)
                    {
                        _manager.ActiveBrowser.Window.SetFocus();
                    }
                    _manager.Desktop.Mouse.Click(MouseClickType.LeftClick, x, y);
                    Thread.Sleep(200 );
                    _manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
                    _manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
                    _manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
                    _manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
                    _manager.Desktop.KeyBoard.KeyPress(Keys.Tab);
