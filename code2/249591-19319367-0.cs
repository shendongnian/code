        DateTime dtLastChangedNotify = DateTime.MinValue;
        TimeSpan tsHumanReactionTime = TimeSpan.FromMilliseconds(100);
        private void MessageProc(IntPtr hwnd, int Msg, IntPtr WParam, IntPtr LParam, ref bool handled)
        {
            if (Msg == WM_CHANGECBCHAIN)
            {
                if (WParam == _nextCBWatcher)
                {
                    _nextCBWatcher = LParam;
                }
                else
                {
                    SendMessage(_nextCBWatcher, Msg, WParam, LParam);
                }
            }
            else if (Msg == WM_DRAWCLIPBOARD)
            {
                uint cpid = 0, pid = 0;
                if (_wasReset)
                {
                    _wasReset = false;
                    return;
                }
                GetWindowThreadProcessId(GetClipboardOwner(), out pid);
                cpid = GetCurrentProcessId();
                // i only want info about what is copied by other programs.
                if (pid != cpid)
                {
                    // filter no human calls.
                    if ((DateTime.Now - dtLastChangedNotify) > tsHumanReactionTime)
                    {
                        OnClipboardChange();
                        dtLastChangedNotify = DateTime.Now;
                    }
                }
                
                SendMessage(_nextCBWatcher, Msg, WParam, LParam);
            }
            else if (Msg == WM_DESTROY)
            {
                ChangeClipboardChain(_ownerWnd, _nextCBWatcher);
            }
        }
