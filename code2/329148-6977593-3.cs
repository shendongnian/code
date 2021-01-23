    public class MyClass
    {
        private BluMote.SettingsForm form;
    
        public MyClass(BluMote.SettingsForm form)
        {
            this.form = form
        }
        private void SetTheTextBox()
        {
            form.send2Display("test");
        }
    }
