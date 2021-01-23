    public class MyClass
    {
        private BluMode.SettingsForm form;
    
        public MyClass(BlueMote.SettingsForm form)
        {
            this.form = form
        }
        private void SetTheTextBox()
        {
            form.send2Display("test");
        }
    }
