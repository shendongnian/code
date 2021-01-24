    [Serializable]
    public class FontInfo : ISerializable
    {
      public FontInfo()
      {
        // Empty constructor required to compile.
      }
    
      public SolidColorBrush BrushColor { get; set; }
      //public FontColor Color { get { return AvailableColors.GetFontColor(this.BrushColor); } }
      public FontFamily Family { get; set; }
      public double Size { get; set; }
      public FontStretch Stretch { get; set; }
      public FontStyle Style { get; set; }
      public FontWeight Weight { get; set; }
    
      public FamilyTypeface Typeface
      {
        get
        {
          FamilyTypeface ftf = new FamilyTypeface()
          {
            Stretch = this.Stretch,
            Weight = this.Weight,
            Style = this.Style
          };
          return ftf;
        }
      }
    
    
      // Implement this method to serialize data. The method is called 
      // on serialization.
      public void GetObjectData(SerializationInfo info, StreamingContext context)
      {
        // Use the AddValue method to specify serialized values.
        info.AddValue(nameof(this.BrushColor), new ColorConverter().ConvertToString(this.BrushColor.Color), typeof(string));
        info.AddValue(nameof(this.Family), new FontFamilyConverter().ConvertToString(this.Family), typeof(string));
        info.AddValue(nameof(this.Stretch), new FontStretchConverter().ConvertToString(this.Stretch), typeof(string));
        info.AddValue(nameof(this.Style), new FontStyleConverter().ConvertToString(this.Style), typeof(string));
        info.AddValue(nameof(this.Weight), new FontWeightConverter().ConvertToString(this.Weight), typeof(string));
        info.AddValue(nameof(this.Size), this.Size, typeof(double));
      }
    
    
      // The special constructor is used to deserialize values.
      public FontInfo(SerializationInfo info, StreamingContext context)
      {
        // Reset the property value using the GetValue method.
        this.BrushColor = new SolidColorBrush((Color) ColorConverter.ConvertFromString((string)info.GetValue(nameof(this.BrushColor), typeof(string))));
        this.Family = (FontFamily) new FontFamilyConverter().ConvertFromString((string)info.GetValue(nameof(this.Family), typeof(string)));
        this.Stretch = (FontStretch) new FontStretchConverter().ConvertFromString((string)info.GetValue(nameof(this.Stretch), typeof(string)));
        this.Style = (FontStyle) new FontStyleConverter().ConvertFromString((string)info.GetValue(nameof(this.Style), typeof(string)));
        this.Weight = (FontWeight) new FontWeightConverter().ConvertFromString((string)info.GetValue(nameof(this.Weight), typeof(string)));
        this.Size = (double) info.GetValue(nameof(this.Size), typeof(double));
      }
    }
