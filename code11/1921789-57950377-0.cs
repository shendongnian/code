c#
[HttpGet("{translation}")]
        public async Task<ActionResult<List<VerseSet>>> GetVerses([FromRoute] string Translation, [FromQuery] string Verse, [FromQuery] bool IncludeVerseNumbers=true)
        {
            VerseService vs = new VerseService(_verseReader);
            List<VerseSet> vList = await vs.GetVerses(Translation, Verse, IncludeVerseNumbers);
            return vList == null ? (ActionResult)NotFound(vList) : Ok(vList);
        }
c#
   public async Task<List<VerseSet>> GetVerses(string TranslationName, string VerseMatchSpec, bool IncludeVerseNumbers)
        {
            ...
            VerseSet v = await ReadVerses(TranslationName, s, IncludeVerseNumbers);
            ...
            return vList;
        }
c#
private async Task<VerseSet> ReadVerses(String TranslationName, String VerseMatchSpec, bool IncludeVerseNumbers)
        {
            ....
            List<VerseInfo> theVerseInfo = await _verseReader.ReadFromStorageAsync(v.Translation, vs.bookname, vs.chapter, vs.v1, vs.v2);
            ...
        }
