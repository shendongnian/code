    public class PictoListViewModel
    {
        public ObservableCollection<PictogramViewModel> Pictograms { get; private set; }
    
        public PictoListViewModel()
        {
            Pictograms = new ObservableCollection<PictogramViewModel>();
            Pictograms.Add(new PictogramViewModel() { ToolTipText = "First", ImageSourcePath = "Images/01.png" });
            Pictograms.Add(new PictogramViewModel() { ToolTipText = "Second", ImageSourcePath = "Images/02.png" });
            Pictograms.Add(new PictogramViewModel() { ToolTipText = "Third", ImageSourcePath = "Images/03.png" });
        }
    }
