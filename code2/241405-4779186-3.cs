    public byte dbGetList2(string key, List<string> list)
    {
        unsafe
        {
            lock (this)
            {
                if (!_disposing)
                {
                    ByteArray* data = (ByteArray*)0;
                    if (_dbGetList2(_handle, key, out data))
                    {
                        int offset = 0;
                        byte* ptr = data->ptr;
                        byte* self = ptr;
                        byte* tmp = self;
                        if ((uint)tmp != 0)
                        {
                            offset = *((int*)(tmp - 4));
                            while (offset-- > 0)
                            {
                                ptr = (byte*)*((int*)tmp);
                                if (*ptr != (byte)0)
                                {
                                    List<byte> bytes = new List<byte>();
                                    do
                                    {
                                        bytes.Add(*ptr++);
                                    }
                                    while (*ptr != (byte)0);
                                    list.Add(Encoding.Default.GetString(bytes.ToArray()));
                                }
                                tmp += 4;
                            }
                        }
                        if (GetLastError())
                        {
                            return _result;
                        }
                    }
                    throw new DatabaseUnknownException();
                }
                throw new DatabaseDisposedException();
            }
        }
    }
