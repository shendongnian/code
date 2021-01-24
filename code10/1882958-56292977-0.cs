            SendIcon = ImageSource.FromResource("SfListViewSample.Images.SendIcon.png", assembly);
            NewText = "";
            SendCommand = new Command(() =>
            {
                if (!string.IsNullOrWhiteSpace(NewText))
                {
                    MessageInfo.Add(new MessageInfo
                    {
 
                        OutgoingMessageIndicator = ImageSource.FromResource("SfListViewSample.Images.OutgoingIndicatorImage.png", assembly),
                        Text = NewText,
                        TemplateType = TemplateType.OutGoingText,
                        DateTime = string.Format("{0:HH:mm}", DateTime.Now)
                    });
                    (ListView.LayoutManager asLinearLayout).ScrollToRowIndex(MessageInfo.Count - 1, Syncfusion.ListView.XForms.ScrollToPosition.Start);
                }
                NewText = null;
            });
