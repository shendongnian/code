    public native long getAddress(long address);
    public native void putAddress(long address, long value);
    public native long allocateMemory(long size);
    public native long reallocateMemory(long l, long l1);
    public native void setMemory(long l, long l1, byte b);
    public native void copyMemory(long l, long l1, long l2);
