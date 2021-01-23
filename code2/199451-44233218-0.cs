            int WM_MOUSEWHEEL   = 0x20a; // or 522
            int WM_VSCROLL      = 0x115; // or 277
            protected override void WndProc(ref Message m)
            {
            //Trap WM_VSCROLL and WM_MOUSEWHEEL message and pass to buddy
            if (Buddies != null)
            {
                
                if (m.Msg == WM_MOUSEWHEEL)  //mouse wheel 
                {
                    foreach (Control ctr in Buddies)
                    {
                        if (!scrolling && ctr != null && ctr.IsHandleCreated)
                        {
                            scrolling = true;
                            if ((int)m.WParam < 0)  //mouse wheel scrolls down
                                SendMessage(ctr.Handle, (int)0x0115, new IntPtr(1), new IntPtr(0)); //WParam: 1- scroll down, 0- scroll up
                            else if ((int)m.WParam > 0)
                                SendMessage(ctr.Handle, (int)0x0115, new IntPtr(0), new IntPtr(0));
                            scrolling = false;
                        }
                    }
                    return; //prevent base.WndProc() from messing synchronization up 
                }
                else if (m.Msg == WM_VSCROLL)
                {
                    foreach (Control ctr in Buddies)
                    {
                        if (ctr != this && !scrolling && ctr != null && ctr.IsHandleCreated)
                        {
                            scrolling = true;
                            SendMessage(ctr.Handle, m.Msg, m.WParam, m.LParam);
                            scrolling = false;
                        }
                    }
                }
            }
            //do the usual
            base.WndProc(ref m);
            }
