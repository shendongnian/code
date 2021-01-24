        public static int WriteCompounds<T>(hid_t groupId, string name, IEnumerable<T> list) //where T : struct
        {
            Type type = typeof(T);
            var size = Marshal.SizeOf(type);
            var cnt = list.Count();
            var typeId = CreateType(type);
            var log10 = (int)Math.Log10(cnt);
            ulong pow = (ulong)Math.Pow(10, log10);
            ulong c_s = Math.Min(1000, pow);
            ulong[] chunk_size = new ulong[] { c_s };
            ulong[] dims = new ulong[] { (ulong)cnt };
            long dcpl = 0;
            if (!list.Any() || log10 == 0) { }
            else
            {
                dcpl = CreateProperty(chunk_size);
            }
            // Create dataspace.  Setting maximum size to NULL sets the maximum
            // size to be the current size.
            var spaceId = H5S.create_simple(dims.Length, dims, null);
            // Create the dataset and write the compound data to it.
            var datasetId = H5D.create(groupId, name, typeId, spaceId, H5P.DEFAULT, dcpl);
            IntPtr p = Marshal.AllocHGlobal(size * (int)dims[0]);
            var ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms);
            foreach (var strct in list)
                writer.Write(getBytes(strct));
            var bytes = ms.ToArray();
            GCHandle hnd = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            var statusId = H5D.write(datasetId, typeId, spaceId, H5S.ALL,
                H5P.DEFAULT, hnd.AddrOfPinnedObject());
            hnd.Free();
            /*
             * Close and release resources.
             */
            H5D.close(datasetId);
            H5S.close(spaceId);
            H5T.close(typeId);
            H5P.close(dcpl);
            Marshal.FreeHGlobal(p);
            return statusId;
        }
