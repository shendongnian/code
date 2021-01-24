    // Concrete class definition
    public class MyOptions
    {
        public string OptionA{ get; set; }
        public string OptionB{ get; set; }
    }
    
    // Passing options to Dialog
    await dc.BeginDialogAsync(nameof(MyDialog), new MyOptions{ OptionA= "MyOptionOneValue", OptionB= "MyOptionTwo" });
    
    // Retrieving options in child Dialog
    using Newtonsoft.Json;
    
    public async Task<DialogTurnResult> MyWaterfallStepAsync(WaterfallStepContext waterfallStepContext, CancellationToken cancellationToken)
    {
        var passedInOptions = waterfallStepContext.Options;
        // Get passed in options, need to serialise the object before we deserialise because calling .ToString on the object is unreliable
        MyOptions passedInMyOptions = JsonConvert.DeserializeObject<MyOptions>(JsonConvert.SerializeObject(waterfallStepContext.Options));
        ...
    
        // Use retrieved options like passedInOptions.OptionA etc
    }
