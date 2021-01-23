	#include <csetjmp>
	#include <iostream>
	using namespace System;
	using namespace System::Runtime::InteropServices;
	using namespace std;
	typedef void (*UnmanagedHandler)(int code);
	void mysetjmp(jmp_buf env, UnmanagedHandler handler)
	{
		handler(setjmp(env));
		throw 0;
	}
	void mylongjmp(jmp_buf env, int val)
	{
		longjmp(env, val);
	}
	namespace jmptestdll
	{
		public delegate void JumpHandler(int code);
		public ref class JumpBuffer
		{
		private:
			jmp_buf *env;
		public:
			JumpBuffer()
			{
				env = new jmp_buf[1];
			}
	
			~JumpBuffer()
			{
				this->!JumpBuffer();
			}
			void Set(JumpHandler^ handler)
			{
				if(env)
				{
					IntPtr ptr = Marshal::GetFunctionPointerForDelegate(handler);
					UnmanagedHandler act = static_cast<UnmanagedHandler>(ptr.ToPointer());
					try{
						mysetjmp(*env, act);
					}catch(int code)
					{
					}
				}
			}
			void Jump(int value)
			{
				if(env)
				{
					mylongjmp(*env, value);
				}
			}
		protected:
			!JumpBuffer()
			{
				if(env)
				{
					delete[] env;
				}
			}
		};
	}
