    public class LinkedList
    {
    int iCount = 1;
    int iCurrent = 0;
    Node nCurrent; 
    #region Properties
    /// <summary>
    /// Give back how many nodes there are.
    /// </summary>
    public int Count
    {
    get
    {
    return iCount;
    }
    } 
    /// <summary>
    /// Gives back the current Node
    /// </summary>
    public Node CurrentNode
    {
    get
    {
    return nCurrent;
    }
    } 
    /// <summary>
    /// Keeps track of the index where you are
    /// </summary>
    public int CurrentNodeIndex
    {
    get
    {
    return iCurrent;
    }
    }
    #endregion 
    /// <summary>
    /// Default and only Constructor
    /// SetUp our LinkedList
    /// </summary>
    /// <param name="obj">Value for the first Node</param> 
    public LinkedList(object obj)
    {
    nCurrent = new Node(null, null, obj);
    nCurrent.Next = null;
    nCurrent.Previous = null;
    } 
    /// <summary>
    /// This function will add another Node
    /// </summary>
    /// <param name="obj">Value for the added Node</param>
    public void AddNode(object obj)
    {
    if(nCurrent.Next == null)
    {
    nCurrent = nCurrent.Next = new Node(nCurrent, null, obj);
    }
    else
    {
    nCurrent = nCurrent.Next = new Node(nCurrent, nCurrent.Next,obj);
    }
    iCount++;
    iCurrent++;
    } 
    /// <summary>
    /// Goes to the next Node
    /// </summary>
    public void ToNext()
    {
    // Checks whether the Next Node is null
    // if so it throws an exception.
    // You can also do nothing but I choos for this.
    if(nCurrent.Next == null)
    {
    throw new Exception("There is no next node!");
    }
    else // If everything is OK
    {
    nCurrent = nCurrent.Next;
    iCurrent++;
    } 
    } 
    /// <summary>
    /// Goes to the previous Node
    /// </summary>
    public void ToPrevious()
    {
    // Look at ToNext();
    if(nCurrent.Previous == null)
    {
    throw new Exception("There is no previous node!");
    }
    else
    {
    nCurrent = nCurrent.Previous;
    iCurrent--;
    } 
    } 
    /// <summary>
    /// Goes to the index you fill in
    /// </summary>
    /// <param name="index">Index Where to go?</param>
    public void GoTo(int index)
    {
    if(iCurrent < index)
    {
    ToNext();
    }
    else if(iCurrent > index)
    {
    ToPrevious();
    }
    }
    } 
