    namespace MyApplication.Properties
    {  
        public sealed partial class Settings
        {
            [global::System.Configuration.UserScopedSettingAttribute()]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            public ObservableCollection<Person> AllPeople
            {
                get
                {
                    return ((ObservableCollection<Person>)(this["AllPeople"]));
                }
                set
                {
                    this["AllPeople"] = value;
                }
            }
        }
    }
