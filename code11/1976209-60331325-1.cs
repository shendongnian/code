                if (attachment is ItemAttachment)
                {
                    var requestUrl = graphClient.Me.Messages[message.Id].Attachments[attachment.Id].RequestUrl + "/item"; 
                    var request = new HttpRequestMessage() {
                        RequestUri = new Uri(requestUrl)
                    };
                    var outlookItemResponse = graphClient.HttpProvider.SendAsync(request);
                   var outlookItem = new ResponseHandler(new Serializer()).HandleResponse<OutlookItem>(outlookItemResponse);
                }
