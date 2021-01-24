     private static async Task<DialogTurnResult> TransportStepAsync(WaterfallStepContext stepContext, CancellationToken cancellationToken)
            {
                string userInput = string.Empty;
    
                // Options contains the information the waterfall dialog was called with
                if (stepContext.Options != null)
                {
                    userInput = stepContext.Options.ToString();
                }
            }
    
     
