public void DebugReplayKeys()
        {
            long startTime = 0;
            Thread td = new Thread(() =>
            {
                int currentIndex = 0;
                bool flag = true;
                while (flag)
                {
                    long ctime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    long runtime = ctime - startTime;
                    var rpk = recordedPressedKeys[currentIndex];
                    if (runtime >= rpk.eventTime)
                    {
                        var tmr = new System.Timers.Timer(Convert.ToDouble(rpk.eventTime));
                        tmr.AutoReset = false;
                        tmr.Elapsed += delegate
                        {
                            ReleaseKey(rpk.key);
                        };
                        PressKey(rpk.key);
                        tmr.Enabled = true;
                        currentIndex++;
                    }
                    if(currentIndex > recordedPressedKeys.Count -1)
                    {
                        flag = false;
                    }
                }
            });
            td.SetApartmentState(ApartmentState.STA);
            startTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            td.Start();
        }
private void PressKey(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_EXTENDEDKEY, 0);
        }
private void ReleaseKey(Keys key)
        {
            keybd_event((byte)key, 0, KEYEVENTF_KEYUP, 0);
        }
[DllImport("user32.dll", SetLastError = true)]
static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
