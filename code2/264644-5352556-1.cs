                // Application Data Usage
            if (ApplicationData.SomeData.ContainsKey("AppKey"))
            {
                ApplicationData.SomeData["AppKey"] = (int)ApplicationData.SomeData["AppKey"] + 1;
            }
            else
            {
                ApplicationData.SomeData["AppKey"] = 1;
            }
            Response.Write("App Data " + (int)ApplicationData.SomeData["AppKey"] + "<br />");
