        public sealed partial class SevenZipCompressor
    #if UNMANAGED
            : SevenZipBase
    #endif
        {
            /// Gets or sets the compression mode.
            /// </summary>
            public CompressionMode CompressionMode { get; set; }
            /// <summary>
            /// Gets or sets the value indicating whether to preserve the 
            ///   directory structure.
            /// </summary>
            public bool DirectoryStructure { get; set; }
        }
