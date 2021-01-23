        StringBuilder sb = new StringBuilder();
        // TODO: Append image headers here.
        // Then append image data:
        for (int i = 0; i != imgbytedata.Length; ++i)
        {
            if ((i % 64) == 0)
            {
                sb.AppendLine();
            }
            sb.AppendFormat("{0:x2}", imgbytedata[i]);
        }
