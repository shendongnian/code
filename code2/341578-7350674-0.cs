    HRESULT __stdcall Helper::FetchImage( /*[out]*/ HBITMAP * hBitmap )
    {
        *hBitmap = NULL; // assume failure
        unique_ptr<CBitmap> bmp(new CBitmap);
    
        // call CreateBitmap and then draw something,
        // ensure it's not selected into a DC when done
    
        *hBitmap = (HBITMAP)bmp->Detach();
        return S_OK;
    }
    // Delete ReleaseImage and all supporting global variables...
    
    // C# example:
    IntPtr ret;
    helper.FetchImage( out ret );
    try {
        Bitmap b = Image.FromHbitmap( ret );
    } finally {
        DeleteObject(ret); // pinvoke call into GDI
    }
