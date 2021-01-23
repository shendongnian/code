     using System.Collections.Generic;
     //
     IDictionary<string, object> kvps = new Dictionary<string, object>();
     kvps.Add("something", 42);
     kvps.Add("else", "entirely");
     object i = kvps["something"];
     string s = kvps["else"] as string;
