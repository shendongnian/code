    // This works in C++
    HDC hOff = ::CreateCompatibleDC( NULL );
    Bitmap oDaBigOne( g_iWidth, g_iHeight, PixelFormat32bppARGB );
    HBITMAP hBMit =  NULL;
    Color oCol( 0, 0, 0, 0 );
    oDaBigOne.GetHBITMAP( oCol, &hBMit );
    HGDIOBJ hSave = ::SelectObject( hOff, hBMit );
