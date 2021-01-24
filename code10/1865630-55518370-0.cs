    private void OnPowerChange(object s, PowerModeChangedEventArgs e)
        {
            switch (e.Mode)
            {
                case PowerModes.Resume:
                    _vm = XmlHelper.ReadConfig(CONFIGPATH);
                    this.DataContext = _vm;
                    if (_vm.Dayly)
                    {
                        ButtonStart_Click(new Button(), null);
                        if (!ni.Visible)
                        {
                            ni.Visible = true;
                        }
                    }
                    break;                
                default: break;
            }
        }
