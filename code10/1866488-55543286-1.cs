    public class Grid<T>
    {
        public T[] array;
    }
    public class ExtendedGrid : Grid<int>  
    {
        string additionalVariable;
    }
    var extendedGrid = new ExtendedGrid(); //No need to specify int as the type argument
