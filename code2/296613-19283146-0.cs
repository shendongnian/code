    long size = GetFileSize(FileName);
    // zero byte
    const int blocksize = 1024;
    // 1's array
    byte[] ntemp = new byte[blocksize];
    byte[] nbyte = new byte[size];
    // init 1's array
    for (int i = 0; i < blocksize; i++)
        ntemp[i] = 0xff;
    
    // get dimensions
    int blocks = (int)(size / blocksize);
    int remainder = (int)(size - (blocks * blocksize));
    int count = 0;
    
    // copy to the buffer
    do
    {
        Buffer.BlockCopy(ntemp, 0, nbyte, blocksize * count, blocksize);
        count++;
    } while (count < blocks);
    
    // copy remaining bytes
    Buffer.BlockCopy(ntemp, 0, nbyte, blocksize * count, remainder);
