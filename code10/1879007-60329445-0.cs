    FulfillmentMessages =
    {
     new Intent.Types.Message
     {
         new Intent.Types.Message
           {
              Platform = Platform.ActionsOnGoogle,
              BasicCard = new BasicCard
              {
                  Title = "<Your Title>",
                  Subtitle="<Your SubTitle>",
                  FormattedText = "<Your Text>",
                  Image = new Image
                  {    ImageUri = "<your Image Url>",
                       AccessibilityText = "<your text here>"
                  },
               Buttons =
                {
                   new BasicCard.Types.Button
                     {
                        Title = "<Your Button Text>",
                        OpenUriAction = new BasicCard.Types.Button.Types.OpenUriAction
                        {
                           Uri = "<your visit url>"
                        }
                    }
                  }
                }
              }
           }
         };
