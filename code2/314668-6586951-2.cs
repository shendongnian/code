    public class ScanDir : ScanItem {
      public List<ScanItem> Items { get; set; }
      public ScanDir() {
        Items = new List<ScanItem>();
      }
    
      public ScanDir CopyWithoutChildren() {
        return new ScanDir() {
          FullPath = this.FullPath,
          ModifiedDate = this.ModifiedDate,
          CreatedDate = this.CreatedDate,
          Attributes = this.Attributes,
          Size = this.Size
        };
      }
    
      public override bool IsDirectory {
        get { return true; }
      }
    }
