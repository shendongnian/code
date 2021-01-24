    case FlightBooking.Intent.Weather:
     // We haven't implemented the GetWeatherDialog so we just display a TODO message.
     var getWeatherMessageText = "TODO: get weather flow here";
     var getWeatherMessage = MessageFactory.Text(getWeatherMessageText, getWeatherMessageText, InputHints.IgnoringInput);
     await turnContext.SendActivityAsync(getWeatherMessage, cancellationToken);
     var attachments = new List<Attachment>();
     meesageReply = MessageFactory.Attachment(attachments); //new variable
     messageReply.Attachments.Add(Cards.CreateAdaptiveCardAttachment());
     break;
