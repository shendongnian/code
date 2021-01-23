    interface IGrid {
        object DataSource { get; }
    }
    interface IGrid<T> {
        T DataSource { get; }
    }
    public Grid : IGrid {
        public object DataSource { get; private set; }
 
        // details elided
    }
    public Grid<T> : IGrid<T> {
        public T DataSource { get; private set; }
        object IGrid.DataSource { get { return this.DataSource; } }
  
        // details elided
    }
    
