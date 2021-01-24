using ByteToFunc;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
namespace eip
{
	internal class Program
    {
        private static void Main(string[] args)
        {
            var vals = Sample.GenericMethod("Nibbles");
            var valg = Sample.GenericMethod(Guid.NewGuid());
            var vali = Sample.GenericMethod(42);
            Console.ReadLine();
        }
    }
    public class Sample
    {
		/* trap values: bad beef is bad food */
		public static int[] EipEspEbpEsiEdiEbxHolder = new[] { 0xBADF00D, 0xBADBEEF, 0xBADF00D, 0xBADBEEF, 0xBADF00D, 0xBADBEEF };
		public static int GenericMethod<T>(T input)
        {
			//How can I get the current memory address
			var subjectAddress = GetAddress(nameof(Sample.SubjectMethod));
			var holderAddress = GetEipEspEbpEsiEdiEbxHolder();
			var captureRegisters = FuncGenerator.Generate<Action<int>, ActionInt>(
				new byte[0].Concat(new byte[]
				{
					0xE8, 0x1C, 0x00, 0x00, 0x00  // call 28
				})
				.Concat(new byte[]
				{
					// save EIP, ESP, EBP, ESI, EDI to temp array
					0x83, 0xC0, 0x1B, // add eax,0x1B (27 bytes)
					0x89, 0x02,		  // mov DWORD PTR [edx],eax
					0x89, 0x62, 0x04, // mov DWORD PTR [edx+0x4],esp
					0x89, 0x6A, 0x08, // mov DWORD PTR [edx+0x8],ebp
					0x89, 0x72, 0x0C, // mov DWORD PTR [edx+0xc],esi
					0x89, 0x7A, 0x10, // mov DWORD PTR [edx+0x10],edi
					0x89, 0x5A, 0x14, // mov DWORD PTR [edx+0x14],ebx
				})
				.Concat(new byte[]
				{
					0xB8, // mov eax
				})
				.Concat(subjectAddress)
				.Concat(new byte[]
				{
					0xFF, 0xD0 // call eax
				})
				.Concat(new byte[]
				{
					0xC3 //retn
				})
				.Concat(new byte[]
				{
					// Helper function for getting EIP as it is inaccessible directly on x86_32
					0x8B, 0x04, 0x24, // mov eax,DWORD PTR [esp]
					0xC3 //retn
				})
				.ToArray()
			);
			captureRegisters(holderAddress);
			Console.WriteLine($"EIP = { EipEspEbpEsiEdiEbxHolder[0].ToString("X") }");
			return 5;
		}
		public static int SubjectMethod()
		{
			return 5;
		}
		private static int GetEipEspEbpEsiEdiEbxHolder()
		{
			unsafe
			{
				var typedReference = __makeref(EipEspEbpEsiEdiEbxHolder);
				int* fieldAddress = (int*)*(int*)*(int*)&typedReference;
				return (int)fieldAddress + 8;
			}
		}
		private static byte[] GetAddress(string name)
		{
			return BitConverter.GetBytes((int)GetRawAddress(name)).ToArray();
		}
		private static IntPtr GetRawAddress(string name)
		{
			var methodHandle = typeof(Sample).GetMethod(name, BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance).MethodHandle;
			RuntimeHelpers.PrepareMethod(methodHandle);
			return methodHandle.GetFunctionPointer();
		}
	}
}
To compile and run, you can use a simple Console project, and add the `FuncGenerator` class by afish from here: https://gist.github.com/afish/8fd6cf8f8c196901b5e1a5ee1000ee68
Result: three different values for EIP, which should be expected.
[![enter image description here][2]][2]
  [1]: https://i.stack.imgur.com/hBTq7.png
  [2]: https://i.stack.imgur.com/mHSuR.png
