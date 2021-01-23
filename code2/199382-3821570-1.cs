    if (DeviceCopy(source, dest))
    {
        if (!DeviceDelete(source))
        {
            if (!DeviceDelete(dest))
            {
                throw new IOException("Oh noes");
            }
        }
    }
