		if (HMODULE hmodRichEdit = LoadLibrary(L"Msftedit.dll"))
		{
			// create richedit window
			if (HWND hwndRich = CreateWindowExW(0, MSFTEDIT_CLASS, ...))
			{
				if (IID* pIID_ITS = (IID*) GetProcAddress(hmodRichEdit, "IID_ITextServices"))
				{
					IUnknown* pUnk;
					if (SendMessageW(hwndRich, EM_GETOLEINTERFACE, 0, (LPARAM)&pUnk))
					{
						ITextServices* pTxtSrv;
						HRESULT hr = pUnk->QueryInterface(*pIID_ITS, (void**)&pTxtSrv);
						pUnk->Release();
						if (0 <= hr)
						{
							pTxtSrv->OnTxPropertyBitsChange(TXTBIT_ALLOWBEEP, 0);
							pTxtSrv->Release();
						}
					}
				}
			}
		}
