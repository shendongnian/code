    public class BaseActivity: AppCompatActivity
    {
        protected override void AttachBaseContext(Context @base)
        {
            base.AttachBaseContext(LanguageManager.LoadLanguage(@base));
        }
    }
