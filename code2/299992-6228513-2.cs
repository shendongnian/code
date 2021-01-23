       public interface IByColumnComparer : IComparer
       {
          string SortColumn { get; set; }
          bool SortDescending { get; set; }
       }
