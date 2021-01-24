                List<byte> data = new List<byte>();
                data.AddRange(BitConverter.GetBytes(F5));
                data.AddRange(BitConverter.GetBytes(TxAddress));
                data.AddRange(BitConverter.GetBytes(TxCommand));
                data.AddRange(BitConverter.GetBytes(TxData));
                data.AddRange(BitConverter.GetBytes(~TxData));
                TxChkSum = 0;
                foreach (byte a in data)
                {
                    TxChkSum += a;
                }
                data.AddRange(BitConverter.GetBytes(TxChkSum));
                dataWriteObject.WriteBytes(data.ToArray());
