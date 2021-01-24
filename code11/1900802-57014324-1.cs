    //Class now gives specificrow as the generic type when inheriting from basedownloader
    class SpecificDownloader : BaseDownloader<SpecificRow>
    {
        //Now InsertToDb has a collection of SpecificRow instead of just row
        public override void InsertToDb(ICollection<SpecificRow> list)
        {
            //implementation
        }
        //other stuff
    }
