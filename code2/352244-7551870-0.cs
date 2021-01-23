    public class AngleConverter : IValueConverter
    {
        public object Convert(...)
        {
            return value;
        }
        ....
    }
    <RotateTransform Angle="{Binding XAxisLabelRotation, 
                                     RelativeSource={RelativeSource
                                          AncestorType={x:Type ContentControl}},
                                     UpdateSourceTrigger=PropertyChanged,
                                     Converter={StaticResource AngleConverter}}" ..>
