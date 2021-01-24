                    var token = JToken.Parse(turnContext.Activity.ChannelData.ToString());
                    if (token["postBack"].Value<bool>())
                    {
                        JToken commandToken = JToken.Parse(turnContext.Activity.Value.ToString());
                        var data = commandToken["Your_Data_ID"].Value<Your_Data_Type>();
                    }
