                string data = "\"STATUS_MESSAGE\": {\"statusMessage\":\" \"some \"bad\" value\"   \", \"addTime\" :\"1294872330\"}";
            Regex rxStatusMessage = new Regex("\\s*\"statusMessage\"\\s*:\"\\s*");
            Regex rxAddTime = new Regex("\",\\s*\"addTime\"\\s*:");
            data = rxStatusMessage.Replace(data, "\x02");
            data = rxAddTime.Replace(data, "\x03");
            Regex rxReplace = new Regex("\x02.*\x03");
            data = rxReplace.Replace(data, m => m.Value.Replace("\"", ""));
            data = data.Replace("\x02", "\"statusMessage\":\"");
            data = data.Replace("\x03", "\", \"addTime\" :");
