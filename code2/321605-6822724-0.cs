    public const int UI_VOLUME_SET = 1101;
        public const int UI_VOLUME_GET = 1100;
        public const int UI_VOLUME_SET_MUTE_STATUS = 1102;
        public const int UI_BRIGHT_GET = 1201;
        public const int UI_BRIGHT_SET = 1202;
        public const int UI_TERMINATE = 9999;
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]Protected override void WndProc(ref Message m)
        {
            int _exoUI = MessageHelper.FindWindow(null, "MY UI");
            EXOxtenderLibrary.VolumeControl _vol;
            switch (m.Msg)
            {
                case UI_TERMINATE:
                    this.Close();
                    break;
                case UI_BRIGHT_GET:
                    //ADD CODE HERE
                    break;
                //case UI_BRIGHT_SET:
                //    //ADD CODE HERE
                //    break;
                case UI_VOLUME_GET:
                    _vol = new EXOxtenderLibrary.VolumeControl();
                    MessageHelper.PostMessage(_exoUI, 32773, _vol.GetVolume(), _vol.isMute);
                    _vol = null;
                    break;
                case UI_VOLUME_SET:
                    _vol = new EXOxtenderLibrary.VolumeControl();
                    _vol.SetVolume(m.WParam.ToInt32());
                    MessageHelper.PostMessage(_exoUI, 32773, _vol.GetVolume(), _vol.isMute);
                    _vol = null;
                    break;
                case UI_VOLUME_SET_MUTE_STATUS:
                    _vol = new EXOxtenderLibrary.VolumeControl();
                    if (m.WParam == new IntPtr(1))
                    { _vol.Mute = true; }
                    else
                    { _vol.Mute = false; }
                    MessageHelper.PostMessage(_exoUI, 32773, _vol.GetVolume(), _vol.isMute);
                    _vol = null;
                    break;
            }
            base.WndProc(ref m);
        }
      
