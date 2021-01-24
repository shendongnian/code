namespace MyCppNamespace
{
    typedef void (__stdcall *callback_function)(int, const char*);
    class CppClass
    {
    private:
        callback_function _callbackFunc;
    
    public:
        void DoSomething(callback_function callbackFunc);
    }
}
**DotNetClass.cs**
namespace MyManagedNamespace
{
    public delegate void ManagedCallback(int size, string message);
}
**CliWrapperClass.h**
#include "CppClass.h"
using namespace MyManagedNamespace;
namespace MyCliNamespace
{
    public ref class CliWrapperClass
    {
    private:
        CppClass *_cppClass;
    public:
        void DoSomething(ManagedCallback ^ callback);
    }
}
**CliWrapperClass.cpp**
#include "CliWrapperClass.h"
namespace MyCliNamespace
{
    void CliWrapperClass::DoSomething(ManagedCallback ^ callback)
    {        
        System::IntPtr callbackPtr = System::Runtime::InteropServices::Marshal::GetFunctionPointerForDelegate(callback);
        _cppClass->DoSomething(static_cast<callback_function>(callbackPtr.ToPointer())); 
    }
}
In the .Net class, you can create an instance of `CliWrapperClass` and call its `DoSomething(...)` function in this way:
namespace MyManagedNamespace
{
    public class ManagedClass
    {
        private ManagedCallback _callback = MyCallback;
        private void MyCallback(int size, string message)
        {
            // Do what you want ...
        }
        public void MyFunction()
        {
            CliWrapperClass wrapper = new CliWrapperClass();
            wrapper.DoSomething(_callback);
        }
    }
}
