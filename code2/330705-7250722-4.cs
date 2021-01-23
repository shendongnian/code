    namespace IPerform.Video.Conversion.Interops
    {
        [ComImport, Guid("6F7BCF72-D0C2-4449-BE0E-B12F580D056D")]
        public class GenericSampleSourceFilter
        {
        }
    
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown),
        Guid("33B9EE57-1067-45fa-B12D-C37517F09FC0")]
        public interface IGenericSampleCB
        {
            [PreserveSig]
            int SampleCallback(IMediaSample pSample);
        }
    
        [Guid("CE50FFF9-1BA8-4788-8131-BDE7D4FFC27F"),
        InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IGenericSampleConfig
        {
            [PreserveSig]
            int SetMediaTypeFromBitmap(BitmapInfoHeader bmi, long lFPS);
    
            [PreserveSig]
            int SetMediaType([MarshalAs(UnmanagedType.LPStruct)] AMMediaType amt);
    
            [PreserveSig]
            int SetMediaTypeEx([MarshalAs(UnmanagedType.LPStruct)] AMMediaType amt, int lBufferSize);
    
            [PreserveSig]
            int SetBitmapCB(IGenericSampleCB pfn);
        }
    }
