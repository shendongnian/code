            private bool _mouseOver = false;
            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case PI.WM_MOUSEMOVE:
                        if (!_mouseOver)
                        {
                            PI.TRACKMOUSEEVENTS tme = new PI.TRACKMOUSEEVENTS();
                            tme.cbSize = (uint)Marshal.SizeOf(typeof(PI.TRACKMOUSEEVENTS));
                            tme.dwHoverTime = 100;
                            tme.dwFlags = (int)(PI.TME_LEAVE);
                            tme.hWnd = Handle;
                            PI.TrackMouseEvent(ref tme);
                            _mouseOver = true;
                        }
                        base.WndProc(ref m);
                        break;
                    case PI.WM_MOUSELEAVE:
                        _mouseOver = false;
                        base.WndProc(ref m);
                        break;
                }
            }
