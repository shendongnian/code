            List<string> GetRegAssociatedFiles(string FileType)
        {
            List<string> _ret = new List<string>();
            Microsoft.Win32.RegistryKey _rk = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(FileType);
            string _defaultapp = _rk.GetValue("").ToString();
            Microsoft.Win32.RegistryKey _rkapp = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(_defaultapp + "\\shell\\open\\command");
            _ret.Add(_rkapp.GetValue("").ToString());
            _rkapp.Close();
            string[] _subkeys = _rk.GetSubKeyNames();
            for (int i = 0; i < _subkeys.Length; i++)
            {
                if (_subkeys[i] == "OpenWithProgIds")
                {
                    Microsoft.Win32.RegistryKey _rkh = _rk.OpenSubKey(_subkeys[i]);
                    string[] _names = _rkh.GetValueNames();
                    for (int j = 0; j < _names.Length; j++)
                    {
                        if (_names[j] == "")
                            continue;
                        Microsoft.Win32.RegistryKey _rhelp = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(_names[j] + "\\shell\\open\\command");
                        _ret.Add(_rhelp.GetValue("").ToString());
                        _rhelp.Close();
                    }
                }
            }
            _rk.Close();
            return _ret;
        }
 
