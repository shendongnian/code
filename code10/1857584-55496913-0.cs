cs
    public class MyDialogManager : IVlcDialogManager
    {
        public async Task<LoginResult> DisplayLoginAsync(IntPtr userdata, IntPtr dialogId, string title, string text, string username, bool askstore,
            CancellationToken cancellationToken)
        {
            return new LoginResult
            {
                Username = "username",
                Password = "password",
                StoreCredentials = false
            };
        }
        public Task DisplayErrorAsync(IntPtr userdata, string title, string text)
        {
            // You could log errors here, or show them to the user
            return Task.CompletedTask;
        }
        public async Task DisplayProgressAsync(IntPtr userdata, IntPtr dialogId, string title, string text, bool indeterminate, float position,
            string cancelButton, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
        public void UpdateProgress(IntPtr userdata, IntPtr dialogId, float position, string text)
        {
        }
        public async Task<QuestionAction?> DisplayQuestionAsync(IntPtr userdata, IntPtr dialogId, string title, string text, DialogQuestionType questionType,
            string cancelButton, string action1Button, string action2Button, CancellationToken cancellationToken)
        {
            return Task.FromResult<QuestionAction?>(null);
        }
    }
Use it like this:
cs
mediaPlayer.Dialogs.UseDialogManager(new MyDialogManager(this));
