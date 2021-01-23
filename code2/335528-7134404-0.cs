        [StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct ForwardingEmptyValueStruct
        {
            int _Row;
            byte _ProviderIdx;
            
    
            public ForwardingEmptyValueStruct(byte providerIdx, int row)
            {
                _ProviderIdx = providerIdx;
                _Row = row;
            }
    
            public double V1
            {
                get { return DataProvider._DataProviders[_ProviderIdx].Value1[_Row];  }
            }
    
            public int V2
            {
                get { return DataProvider._DataProviders[_ProviderIdx].Value2[_Row];  }
            }
        }
