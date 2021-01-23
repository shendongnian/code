    m_notifyIcon.MouseUp += new Forms.MouseEventHandler(m_notifyIcon_MouseUp);
    m_notifyIcon.ContextMenuStrip = notifyContext;
    
    Handling the left click event and show the main contextmenu:
    
            void m_notifyIcon_MouseUp(object sender, Forms.MouseEventArgs e)
            {
                if (e.Button == Forms.MouseButtons.Left)
                {
                    mainContext.IsOpen = ! mainContext.IsOpen;
                }
            }
