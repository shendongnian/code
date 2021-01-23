    [ViewExport(RegionName = RegionNames.MyRegion)]
    public partial class MyView : UserControl {
        public MyView() {
            this.InitializeComponent();
        }
    
        [Import]
        public MyViewModel ViewModel {
            set { DataContext = value; }
        }
    }
    
    [Export]
    public class MyViewModel : ViewModelBase
    [
      ...
    }
