    public static void ChartColorAssignment()
        {
            CartesianMapper<double> _dapperMapper = new CartesianMapper<double>()
                .X((value, index) => index)
                .Y((value) => value)
                .Fill((value, index) => (value > 3.0 ? Brushes.DodgerBlue : Brushes.Yellow));
            Charting.For<double>(_dapperMapper, SeriesOrientation.Horizontal);
            var doubleMapperWithMonthColors = new CartesianMapper<double>()
                .X((value, index) => index)
                .Y((value) => value)
                .Fill((v, i) =>
                {
                    switch (i % 12)
                    {
                        case 0: return Brushes.ForestGreen; //january
                        case 1: return Brushes.Coral; //february
                        case 2: return Brushes.Crimson; //march
                        case 3: return Brushes.OrangeRed; //april
                        case 4: return Brushes.DarkViolet; //may
                        case 5: return Brushes.Chocolate; //june
                        case 6: return Brushes.MediumVioletRed; //july
                        case 7: return Brushes.SteelBlue; //august
                        case 8: return Brushes.Orange; //september
                        case 9: return Brushes.Teal; //october
                        case 10: return Brushes.RosyBrown; //november
                        case 11: return Brushes.YellowGreen; //december 
                        default: return Brushes.Red;
                    }
                });
    
            Charting.For<double>(doubleMapperWithMonthColors, SeriesOrientation.Horizontal);
        }
