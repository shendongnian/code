    public partial class DetailComponent : StackLayout {
            public DetailComponent() {
                InitializeComponent();
    
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    this.BodyLabel.HeightRequest = DeviceDisplay.MainDisplayInfo.Height * 0.25;
                } else
                {
                    this.BodyLabel.HeightRequest = DeviceDisplay.MainDisplayInfo.Height * 0.33;
                }
            }
        }
