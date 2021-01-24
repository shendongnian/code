    public class ErrorModel
    {
      #region Properties
      public string FilePath { get; set; }
      public int Line { get; set; }
      public int Column { get; set; }
      public TaskErrorCategory Category { get; set; }
      public string Description { get; set; }
      public IVsHierarchy HierarchyItem { get; set; }
      #endregion
    }
