    public virtual byte[] ReadBytes(int count) {
        if (count < 0) throw new ArgumentOutOfRangeException("count", Environment.GetResourceString("ArgumentOutOfRange_NeedNonNegNum")); 
        Contract.Ensures(Contract.Result<byte[]>() != null); 
        Contract.Ensures(Contract.Result<byte[]>().Length <= Contract.OldValue(count));
        Contract.EndContractBlock(); 
        if (m_stream==null) __Error.FileNotOpen();
        byte[] result = new byte[count];
 
        int numRead = 0;
        do { 
            int n = m_stream.Read(result, numRead, count); 
            if (n == 0)
                break; 
            numRead += n;
            count -= n;
        } while (count > 0);
 
        if (numRead != result.Length) {
            // Trim array.  This should happen on EOF & possibly net streams. 
            byte[] copy = new byte[numRead]; 
            Buffer.InternalBlockCopy(result, 0, copy, 0, numRead);
            result = copy; 
        }
        return result;
    } 
