    public class TestValueResolver : ValueResolver<string, Gender?>
    {
        protected override Gender? ResolveCore(string source)
        {
            if (source.StartsWith("M", System.StringComparison.OrdinalIgnoreCase))
            {
                return Gender.Male;
            }
    
            else if (source.StartsWith("F", System.StringComparison.OrdinalIgnoreCase))
            {
                return Gender.Female;
            }
    
            return null;
        }
    }
    
    public class GenderFormatter : ValueFormatter<Gender?>
    {
        protected override string FormatValueCore(Gender? value)
        {
            switch (value)
            {
                case Gender.Male:
                    return "M";
                case Gender.Female:
                    return "F";
                default:
                    return null;
            }
        }
    }
