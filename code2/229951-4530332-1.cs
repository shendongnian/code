    class Page
    {
        Field Parent {get;set;}
        IEnumerable<Field> Children {get;set;}
    }
    class Field 
    {
        Page Parent {get;set;}
        IEnumerable<Field> Children {get;set;}
    }
