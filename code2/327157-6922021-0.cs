    public static int VarPtr(object e)
    {
        GCHandle GC = GCHandle.Alloc(e, GCHandleType.Pinned);
        int gc = GC.AddrOfPinnedObject().ToInt32();
        GC.Free();
        return gc;
    }
