    void PumpMessages()
    {
        MSG msg;
        for( ;; ) {
            if( !PeekMessage( &msg, 0, 0, 0, PM_REMOVE ) ) {
                return;
            }
            if( msg.message == WM_QUIT ) {
                s_stopped = true;
                return;
            }
            TranslateMessage( &msg );
            DispatchMessage( &msg );
        }
    }
