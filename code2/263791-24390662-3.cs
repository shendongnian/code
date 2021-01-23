    [DllImport( "qwave.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true )]
    internal static extern bool QOSCreateHandle( ref QosVersion version, out QosSafeHandle qosHandle );
    [DllImport( "qwave.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true )]
    [ReliabilityContract( Consistency.WillNotCorruptState, Cer.Success )]
    internal static extern bool QOSCloseHandle( IntPtr qosHandle );
    [DllImport( "qwave.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true )]
    internal static extern bool QOSAddSocketToFlow(
        QosSafeHandle qosHandle,
        IntPtr socket,
        byte[] destAddr,
        QosTrafficType trafficType,
        QosFlowFlags flags,
        ref uint flowId
    );
    /// <summary>
    /// Safely stores a handle to the QWave QoS win32 API and ensures the handle is properly 
    /// closed when all references to the handle have been garbage collected.
    /// </summary>
    public class QosSafeHandle : SafeHandle
    {
        /// <summary>
        /// Initializes a new instance of the QosSafeHandle class.
        /// </summary>
        public QosSafeHandle() :
            base( IntPtr.Zero, true )
        {
        }
        /// <summary>
        /// Whether or not the handle is invalid.
        /// </summary>
        public override bool IsInvalid
        {
            get { return this.handle == IntPtr.Zero; }
        }
        /// <summary>
        /// Releases the Qos API instance handle.
        /// </summary>
        /// <returns></returns>
        protected override bool ReleaseHandle()
        {
            QosNativeMethods.QOSCloseHandle( this.handle );
            return true;
        }
    }
