    interface IGroupNode
    { }
    
    class Group : IGroupNode
    {
        List<IGroupNode> Children { get; set; }
    }
    
    class Segment : IGroupNode
    {
        List<Field> Fields { get; set; }
    }
    
    class Field
    {
        bool myProperty { get; set; }
    }
