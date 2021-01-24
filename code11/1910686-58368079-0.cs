     void Decompress()
     {
            var bytes = System.Convert.FromBase64String(DataString);
            var tmp_size = bytes.Length/4;
            int idx = 0;
            List<float> mz_list = new List<float>();
            List<float> intensity_list = new List<float>();
            string Out = "I";
            foreach (object tmp in StructConverter.Unpack(tmp_size, "", bytes))
            {
                var tmp_i = StructConverter.Pack(new object[] { tmp }, false, out Out);
                var tmp_f = StructConverter.Unpack("f", tmp_i)[0];
                if (idx % 2 == 0) mz_list.Add((float)(tmp_f));
                else intensity_list.Add((float)(tmp_f));
                idx++;
            }
            X = mz_list;
            Y = intensity_list;
    }
