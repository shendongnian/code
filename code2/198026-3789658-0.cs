    public class CovariantList<TType, TBase> : IList<TBase>
    where TType:TBase,class
    {
    private IList<TType> _innerList;
    
    public int Count
    {
    get
    {
    return this._innerList.Count;
    }
    }
    
    public TBase this[int index]
    {
    get
    {
    return this._innerList[index];
    }
    set
    {
    TType type = value as TType;
    if(type!=null)
    {
    ...
    }
    }
    ...
