    // SERVER: C#
	using System.Runtime.InteropServices;
	namespace COMInteroperability
	{
		[Guid("6650E916-B507-483e-9804-8EEDA770F76C")]
		interface IFoo
		{
			[ComVisible(true)]
			string Bar(int value);
		}
		[ClassInterface(ClassInterfaceType.AutoDual)]
		[Guid("92377D62-32CB-4b2b-AE79-B256F54B3E17")]
		public class Foo : IFoo
		{
			public string Bar(int value)
			{
				throw new Exception("A dotnet exception...");
			}
		}
	}
    // CLIENT: C++
	#include "stdafx.h"
	#import "G:\temp\COMInteroperability\COMInteroperability\COMInteroperability\bin\Debug\COMInteroperability.tlb" no_namespace names_guids raw_interfaces_only
	void CheckResult(HRESULT hr)
	{
		if (SUCCEEDED(hr)) return;
		CComPtr<IErrorInfo> error;
		if (FAILED(GetErrorInfo(0, &error))) return;
		
		if (!error.p) return;
			
		CComBSTR description;
		error->GetDescription(&description);
		wprintf(description.m_str);
	}
	int _tmain(int argc, _TCHAR* argv[])
	{
		CoInitialize(0);
		{
			CComPtr<_Foo> foo;
			CLSID clsid;
			CLSIDFromString(L"{92377D62-32CB-4b2b-AE79-B256F54B3E17}", &clsid);
			HRESULT hr = foo.CoCreateInstance(clsid);
			
			CheckResult(hr);
			if (FAILED(hr))
			{
				printf("Error %x", hr);
				return -1;
			}
			CComBSTR ret;
			CheckResult(foo->raw_Bar(10, &ret));
		}
		CoUninitialize();
	}
