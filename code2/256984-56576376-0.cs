csharp
public class UniqueList<T>
{
    public List<T> List
    {
        get;
        private set;
    }
    List<T> _internalList;
    
    public static UniqueList<T> NewList
    {
        get
        {
            return new UniqueList<T>();
        }
    }
    private UniqueList()
    {            
        _internalList = new List<T>();
        List = new List<T>();
    }
    public void Add(T value)
    {
        List.Clear();
        _internalList.Add(value);
        List.AddRange(_internalList.Distinct());
        //return List;
    }
    public void Add(params T[] values)
    {
        List.Clear();
        _internalList.AddRange(values);
        List.AddRange(_internalList.Distinct());
       // return List;
    }
    public bool Has(T value)
    {
        return List.Contains(value);
    }
}
and you can use it like follows
charp
var uniquelist = UniqueList<string>.NewList;
uniquelist.Add("abc","def","ghi","jkl","mno");
uniquelist.Add("abc","jkl");
var _myList = uniquelist.List;
will only return `"abc","def","ghi","jkl","mno"` always even when duplicates are added to it
