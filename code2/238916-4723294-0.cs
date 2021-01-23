    using System.Linq;
    using System.Collections;
    using System.Collections.Generic;
    ...
    
    Dictionary<string, string> form = new Dictionary<string, string>(from key in Request.Form.AllKeys select new DictionaryEntry(key, Request.Form[key]));
    Session["MyKey"] = form;
