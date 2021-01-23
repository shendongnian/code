    public class Node
    {
    protected Node nPrevious;
    protected Node nNext;
    protected object Object; 
    #region Properties
    public object Value
    {
    get
    {
    return Object;
    }
    set
    {
    Object = value;
    }
    } 
    public Node Previous
    {
    get
    {
    return nPrevious;
    }
    set
    {
    nPrevious = value;
    }
    } 
    public Node Next
    {
    get
    {
    return nNext;
    }
    set
    {
    nNext = value;
    }
    }
    #endregion 
    public Node(Node PrevNode, Node NextNode, object obj)
    {
    nPrevious = PrevNode;
    nNext = NextNode;
    Object = obj;
    }
    } 
    
