        [StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
    private struct WLAN_ASSOCIATION_ATTRIBUTES
    {
        /// <summary>
        /// A DOT11_SSID structure that contains the SSID of the association.
        /// </summary>
        [FieldOffset(0)]
        public DOT11_SSID dot11Ssid;
        /// <summary>
        /// A DOT11_BSS_TYPE value that specifies whether the network is infrastructure or ad hoc.
        /// </summary>
        [FieldOffset(0x24)]
        public DOT11_BSS_TYPE dot11BssType;
        /// <summary>
        /// A DOT11_MAC_ADDRESS that contains the BSSID of the association.
        /// </summary>
        [FieldOffset(40)]
        public DOT11_MAC_ADDRESS dot11Bssid;
        /// <summary>
        /// A DOT11_PHY_TYPE value that indicates the physical type of the association
        /// </summary>
        [FieldOffset(0x30)]
        public DOT11_PHY_TYPE dot11PhyType;
        /// <summary>
        /// The position of the DOT11_PHY_TYPE value in the structure containing the list of PHY types.
        /// </summary>
        [FieldOffset(0x34)]
        public ulong uDot11PhyIndex;
        /// <summary>
        /// A percentage value that represents the signal quality of the network.
        /// </summary>
        [FieldOffset(0x38)]
        public Int32 wlanSignalQuality;
        /// <summary>
        /// Contains the receiving rate of the association.
        /// </summary>
        [FieldOffset(60)]
        public ulong ulRxRate;
        /// <summary>
        /// Contains the transmission rate of the association.
        /// </summary>
        [FieldOffset(0x40)]
        public ulong ulTxRate;
    }
