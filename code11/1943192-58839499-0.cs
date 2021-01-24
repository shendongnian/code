        private async Task<DialogTurnResult> StepOne(WaterfallStepContext stepContext, CancellationToken cancellationToken)
             {
                return await stepContext.PromptAsync(nameof(TextPrompt), new PromptOptions Prompt = promptMessage70 }, cancellationToken);
             }
            
             
            
        private async Task<DialogTurnResult> StepTwo(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
              // Get the user response from StepOne: 
              var value = ((string)stepContext.Result);
              // we pass the value to CardJson
              reply70.Attachments.Add(Cards.CardJson(value));
              await stepContext.Context.SendActivityAsync(reply70,cancellationToken);
            }
