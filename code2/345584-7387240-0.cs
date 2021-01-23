    class VisualBase<T> where T : BusinessBase
    {
        T BusinessObject {get; set;}
    }
    class VisualChild1 : VisualBase<BusinessChild1>
    {
        ...
    }
