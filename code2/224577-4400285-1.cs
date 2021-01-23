    List<double> list = new List<double>();
    list.Add(Math.PI);
    list.Add(34.22);
    byte[] res = new byte[list.Count * sizeof(double)];
    unsafe
    {
        fixed (byte* pres = res)
        {
            for (int i = 0; i < list.Count; i++)
            {
                *(((double*)pres) + i) = list[i];
            }
        }
    }
