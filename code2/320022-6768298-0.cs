    // MyWebService.cpp : main project file.
    #include "stdafx.h"
    #include "Global.asax.h"
    #include "HeaderFileGeneratedByWsdlExe.h"
    
    using namespace System;
    using namespace System::Web;
    using namespace System::Web::Services;
    
    namespace MyWebService {
    
    	[WebService(Namespace = L"http://MyNamespace.org/")]
    	[WebServiceBinding(ConformsTo = WsiProfiles::BasicProfile1_1)]
    	public ref class MyWebService : public System::Web::Services::WebService
    	{
        public:
    		
    		[WebMethod(Description = L"myMethod does something")]
            System::Void myMethod(MyClass ^myInstance)
    		{
    			DoSth(myInstance);
    		}
    	};
    }
