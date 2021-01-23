    void MethodThatUsesBoth()
    {
       lock(((ICollection)aList).SyncRoot){
           lock(((ICollection)bList).SyncRoot){
                 //Works with both lists
           }
       }
    }
    void MethodThatUsesAList()
    {
       lock(((ICollection)aList).SyncRoot){
       }
    }
    void MethodThatUsesBList()
    {
       lock(((ICollection)bList).SyncRoot){
       }
    }
