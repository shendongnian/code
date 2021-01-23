    pubic interface ISessionData
    {
        ExtraFieldsLinker CurrentExtraFieldsLinker { get; set; }
    }
    public class SessionDataImpl : ISessionData
    {
        ExtraFieldsLinker CurrentExtraFieldsLinker
        {
            get { return (ExtraFieldsLinker)GetSessionObject(EXTRA_FIELDS_LINKER); }
            set { SetSessionObject(EXTRA_FIELDS_LINKER, value); }
        }
    }
    public class ClassThatContainsYourAction
    {
        static ClassThatContainsYourAction()
        {
            SessionData = new SessionDataImpl();
        }
        public static ISessionData SessionData { get; private set; }
        // Making this access very ugly so you don't do it by accident
        public void SetSessionDataForUnitTests(ISessionData sessionData)
        {
            SessionData = sessionData;
        }
        [HttpPost]
        public JsonResult GetSearchResultGrid(JqGridParams gridParams,
            Guid campaignId, string queryItemsString)
        {
            // ...
        }
    }
