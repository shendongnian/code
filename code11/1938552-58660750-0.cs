	using System;
	using System.Runtime.InteropServices;
	namespace aac
	{
		class Program
		{
			static void Main(string[] args)
			{
			    // Just test the init function
				MosquittoWrapper.mosquitto_lib_init();
				Console.WriteLine("success");
			}
		}
		public static class MosquittoWrapper
		{
		    // Same name as DLL
			public const string MosquittoDll = "mosquitto";
            // https://mosquitto.org/api/files/mosquitto-h.html#mosquitto_lib_init
			[DllImport(MosquittoDll, CallingConvention = CallingConvention.Cdecl)]
			public static extern int mosquitto_lib_init();
		}
	}
