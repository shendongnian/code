    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    public class DirectSoundDevices
    {
        [DllImport("dsound.dll", CharSet = CharSet.Ansi)]
        static extern void DirectSoundCaptureEnumerate(DSEnumCallback callback, IntPtr context);
        delegate bool DSEnumCallback([MarshalAs(UnmanagedType.LPStruct)] Guid guid,
            string description, string module, IntPtr lpContext);
        static bool EnumCallback(Guid guid, string description, string module, IntPtr context)
        {
            if (guid != Guid.Empty)
                captureDevices.Add(new DirectSoundDeviceInfo(guid, description, module));
            return true;
        }
        private static List<DirectSoundDeviceInfo> captureDevices;
        public static IEnumerable<DirectSoundDeviceInfo> GetCaptureDevices()
        {
            captureDevices = new List<DirectSoundDeviceInfo>();
            DirectSoundCaptureEnumerate(new DSEnumCallback(EnumCallback), IntPtr.Zero);
            return captureDevices;
        }
    }
    public class DirectSoundDeviceInfo
    {
        public DirectSoundDeviceInfo(Guid guid, string description, string module)
        { Guid = guid; Description = description; Module = module; }
        public Guid Guid { get; }
        public string Description { get; }
        public string Module { get; }
    }
