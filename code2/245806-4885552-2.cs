    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    
    namespace GmailReader
    {
        [Serializable,
        ComVisible(true)]
        public class GmailList : List<GmailItem>
        {
            public GmailList() { }
        }
    [Serializable,
    ComVisible(true)]
    public class GmailItem
    {
        public GmailItem() { }
        public string Title;
        public string Summary;
        public string Link;
        public string AuthorName;
        public string AuthorEmail;
        /*public DateTime Issued;
        public DateTime Modified;*/
        public string ID;
    }
}
