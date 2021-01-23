    #include <vcclr.h>
    using namespace System;
    using namespace ONEAPI;
    namespace Bot {
        class ConnectionWrapper {
        public:
            static gcroot<ONEAPI::Connection^> connection;
        };
        gcroot<ONEAPI::Connection^> ConnectionWrapper::connection = gcnew Connection(true);
        void InitializeBot() {
            ConnectionWrapper::connection->StartConnection(...);
        }
    }
