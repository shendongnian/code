                // Session Data Usage.
            if (SessionData.SomeData.ContainsKey("SessionKey"))
            {
                SessionData.SomeData["SessionKey"] = (int)SessionData.SomeData["SessionKey"] + 1;
            }
            else
            {
                SessionData.SomeData["SessionKey"] = 1;
            }
            Response.Write("Session Data " + (int)SessionData.SomeData["SessionKey"] + "<br />");
