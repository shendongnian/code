// Test.cpp in NativeLib.dll
namespace Testing
{
	class __declspec(dllexport) Test
	{
	public:
		explicit Test(int data)
			: data(data)
		{
		}
		int Run(char const * path)
		{
			return this-&gt;data + strlen(path);
		}
	private:
		int data;
	};
}
// Program.cs in CSharpClient.exe
class Program
    {
        [DllImport(
            "NativeLib.dll",
            EntryPoint = "??0Test@Testing@@QAE@H@Z",
            CallingConvention = CallingConvention.ThisCall,
            CharSet = CharSet.Ansi)]
        public static extern void TestingTestCtor(IntPtr self, int data);
        [DllImport(
            "NativeLib.dll",
            EntryPoint = "?Run@Test@Testing@@QAEHPBD@Z",
            CallingConvention = CallingConvention.ThisCall,
            CharSet = CharSet.Ansi)]
        public static extern int TestingTestRun(IntPtr self, string path);
        static void Main(string[] args)
        {
            var test = Marshal.AllocCoTaskMem(4);
            TestingTestCtor(test, 10);
            var result = TestingTestRun(test, "path");
            Console.WriteLine(result);
            Marshal.FreeCoTaskMem(test);
        }
    }
