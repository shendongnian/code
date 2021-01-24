    class Program
    {
        static void Main(string[] args)
        {
            // using DirectN
            var enumerator = (IMMDeviceEnumerator)new MMDeviceEnumerator();
            // or call GetDevice(...) with an id
            enumerator.GetDefaultAudioEndpoint(
                __MIDL___MIDL_itf_mmdeviceapi_0000_0000_0001.eCapture,
                __MIDL___MIDL_itf_mmdeviceapi_0000_0000_0002.eConsole,
                out var device).ThrowOnError();
            const int CLSCTX_ALL = 23;
            device.Activate(typeof(IDeviceTopology).GUID, CLSCTX_ALL, null, out var iface).ThrowOnError();
            var topology = (IDeviceTopology)iface;
            topology.GetConnector(0, out var connector).ThrowOnError();
            var part = (IPart)connector;
            if (part.Activate(CLSCTX_ALL, typeof(IAudioAutoGainControl).GUID, out iface).IsError)
            {
                Console.WriteLine("AGC not supported.");
                return;
            }
            var control = (IAudioAutoGainControl)iface;
            control.SetEnabled(true, IntPtr.Zero);
        }
        [ComImport]
        [Guid("bcde0395-e52f-467c-8e3d-c4579291692e")] // CLSID_MMDeviceEnumerator
        class MMDeviceEnumerator
        {
        }
    }
