        protected Test(SerializationInfo info, StreamingContext context)
        {         
            sx = info.GetUInt16("sizex");
            sy = info.GetUInt16("sizey");
            sz = info.GetUInt16("sizez");
            ushort[] tab = new ushort[sx * sy * sz];
            tab = (ushort[])info.GetValue("data", tab.GetType());
            Console.WriteLine("Deserializing constructor");
        }
