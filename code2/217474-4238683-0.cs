    using NationalInstruments.UI.WindowsForms;
    private NationalInstruments.UI.WindowsForms.Slide noiseSlide;
    private void InitializeComponent()
    {
    ...
    this.noiseSlide.FillBaseValue = -20;
    this.noiseSlide.Location = new System.Drawing.Point(8, 136);
    this.noiseSlide.Name = "noiseSlide";
    this.noiseSlide.Range = new NationalInstruments.UI.Range(-100, 0);
    this.noiseSlide.ScalePosition = NationalInstruments.UI.NumericScalePosition.Bottom;
    ...
    }
