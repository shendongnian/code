    public class Crate
    {
        IList<KeyValuePair<string,SectionConfiguration>> Sections ;
        public bool IsValid()
        {
            return Sections.All( x => x.Value.PixelsWide == Sections.FirstOrDefault().Value.PixelsWide ) ;
        }
        public class SectionConfiguration
        {
            public int PixelsWide ;
        }
    }
