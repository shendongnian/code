    [Serializable]
    public class CustomPromptDialog : IDialog<string>
    {
        public async Task StartAsync(IDialogContext context)
        {
            List<string> choices = new List<string>();
            choices.Add("Choice 1");
            choices.Add("Choice 2");
            PromptDialog.Choice(context, ResumeAfter, choices, "Title", "Wrong!", 5);
           
        }
        public async Task ResumeAfter(IDialogContext context, IAwaitable<string> result)
        {
                try{ 
                     var choice = await result;
                    context.Done(choice);
                }catch(Exception e){
                    // Code here after "Too Many Attempts" message
                }
               
        }
    }
