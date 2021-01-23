    public class FetchWordsIntegrationViewModel
    {
        public IList<SelectListItemBase> WordTypes { get; private set; }
    
        public FetchWordsIntegrationViewModel()
        {
            WordTypes = new List<SelectListItemBase>();
    
            WordTypes.Add(new SelectListItemBase() { Value = "0", Text = Constants.Ids.SelectionListDefaultText });
            WordTypes.Add(new SelectListItemBase() { Value = ((int)FetchedWordType.ProperNoun).ToString(), Text = "Proper noun" });
            // other select list items here
        }
    }
