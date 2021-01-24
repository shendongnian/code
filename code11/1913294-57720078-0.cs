 C++
HDESK activeDesktop = OpenInputDesktop(0, FALSE, DESKTOP_READOBJECTS | DESKTOP_JOURNALPLAYBACK | DESKTOP_JOURNALRECORD);
	if (activeDesktop)
	{
		WCHAR desktopName[MAX_PATH];
		DWORD lengthNeeded;
		if (GetUserObjectInformation(activeDesktop, UOI_NAME, desktopName, ARRAYSIZE(desktopName), &lengthNeeded))
		{
			OutputDebugString(desktopName);
			OutputDebugString(L"\r\n");
		}
		else
		{
			OutputDebugString(L"Failed 1\r\n");
		}
		CloseDesktop(activeDesktop);
	}
	else
	{
		OutputDebugString(L"Failed 2\r\n");
	}
If Winlogon, OpenInputDesktop would fail.
