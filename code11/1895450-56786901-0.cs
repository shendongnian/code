    _LogMessage = new  UiPath.Core.Activities.LogMessage
                {
                    Level = this.Level,
                    Message = new InArgument<string>(message),
                };
