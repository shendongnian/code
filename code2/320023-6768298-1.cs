    // MyWebService.cpp : main project file.
    #include "stdafx.h"
    #include "Global.asax.h"
    #include "HeaderFileGeneratedByWsdlExe.h"
    
    using namespace System;
    using namespace System::Web;
    using namespace System::Web::Services;
    
    namespace MyWebService {
    
    	[WebService(Namespace = L"http://MyNamespace.org/")]
    	public ref class MyWebService : public InterfaceFromHeaderFile
    	{
        public:
    		
            System::Void myMethod(MyClass ^myInstance)
    		{
    			DoSth(myInstance);
    		}
    	};
    }
