 public ObservableCollection<gridItems> items = new ObservableCollection<gridItems>();
   try
            {
                string[] folderPaths = Directory.GetDirectories(stemp);
                items.Clear();
                foreach (string s in folderPaths)
                {
                    items.Add(new gridItems { foldername = s.Remove(0, s.LastIndexOf('\\') + 1), folderpath = s });
                }
            }
            catch (Exception a)
            {
                
            }
  public class gridItems
    {
        public string foldername { get; set; }
        public string folderpath { get; set; }
    }
