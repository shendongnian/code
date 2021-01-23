    public class Range {
    
      public int Start { get; private set; }
      public int End { get; private set; }
    
      public Range(int start, int end) {
        Start = start;
        End = end;
      }
  
      public IEnumerable<Range> RemoveFrom(Range range) {
        return RemoveFrom(new Range[] { range });
      }
    
      public IEnumerable<Range> RemoveFrom(IEnumerable<Range> items) {
        foreach (Range item in items) {
          if (End >= item.Start && Start <= item.End) {
            if (item.Start <= Start) {
              yield return new Range(item.Start, Start);
            }
            if (item.End >= End) {
              yield return new Range(End, item.End);
            }
          } else {
            yield return item;
          }
        }
      }
    
    }
