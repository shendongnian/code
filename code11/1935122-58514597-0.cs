        [StructLayout(LayoutKind.Sequential)]
        public struct BTH_LE_UUID
        {
            public Byte isShortUuid;
            public UInt16 ShortUuid;
            public Guid LongUuid;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct BTH_LE_GATT_CHARACTERISTIC
        {
            public UInt16 ServiceHandle;
            public BTH_LE_UUID CharacteristicUuid;
            public UInt16 AttributeHandle;
            public UInt16 CharacteristicValueHandle;
            public Byte IsBroadcastable;
            public Byte IsReadable;
            public Byte IsWritable;
            public Byte IsWritableWithoutResponse;
            public Byte IsSignedWritable;
            public Byte IsNotifiable;
            public Byte IsIndicatable;
            public Byte HasExtendedProperties;
        }
