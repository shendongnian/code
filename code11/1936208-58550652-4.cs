    public static class Extensions
    {
        private static readonly Dictionary<LengthUnit, string> CompoundWordUnits =
            new Dictionary<LengthUnit, string>
            {
                {LengthUnit.AstronomicalUnit, "astronomical unit"},
                {LengthUnit.DtpPica, "dtp pica"},
                {LengthUnit.DtpPoint, "dtp point"},
                {LengthUnit.KilolightYear, "kilolight-year"},
                {LengthUnit.LightYear, "light-year"},
                {LengthUnit.MegalightYear, "megalight-year"},
                {LengthUnit.NauticalMile, "nautical mile"},
                {LengthUnit.PrinterPica, "printer pica"},
                {LengthUnit.PrinterPoint, "printer point"},
                {LengthUnit.SolarRadius, "solar radius"},
                {LengthUnit.UsSurveyFoot, "US survey foot"},
            };
        private static readonly Dictionary<LengthUnit, string> SpecialPluralUnits =
            new Dictionary<LengthUnit, string>
            {
                {LengthUnit.Foot, "feet"},
                {LengthUnit.Inch, "inches"},
                {LengthUnit.Microinch, "microinches"},
                {LengthUnit.SolarRadius, "solar radii"},
                {LengthUnit.UsSurveyFoot, "US survey feet"},
            };
        public static string ToFullUnitString(this Length length)
        {
            if (length == null) throw new ArgumentNullException(nameof(length));
            // Get the singular form
            var unit = CompoundWordUnits.ContainsKey(length.Unit)
                ? CompoundWordUnits[length.Unit]
                : length.Unit.ToString().ToLower();
            // Get the plural form if needed
            if (length.Value != 1)
                unit = SpecialPluralUnits.ContainsKey(length.Unit)
                    ? SpecialPluralUnits[length.Unit]
                    : $"{unit}s";
            return $"{length:v} {unit}";
        }
    }
