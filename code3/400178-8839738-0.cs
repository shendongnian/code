    long pOutHB;
		
    pQRCodePtr->Generate(m_sQRText.AllocSysString(), 200, 200, &pOutHB);
    HBITMAP hb1 = (HBITMAP) pOutHB;
		
    HBITMAP oldHB = m_QRCodePicture.SetBitmap(hb1);
    if (oldHB)
    {
        DeleteObject(oldHB);
    }
