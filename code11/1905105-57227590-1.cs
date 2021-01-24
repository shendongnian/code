public MainDialog(UserState userState)
            : base(nameof(MainDialog))
        {
            _userState = userState;
            AddDialog(new DIALOG_CLASS_I_WANT_TO_START());
            InitialDialogId = nameof(aDifferentDialogNotShownHere);
        }
or to your startup.cs as a transient:
public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //all the other configure stuff...
            // Register dialogs
            services.AddTransient<MainDialog>();
            services.AddTransient<DIALOG_CLASS_I_WANT_TO_START>();
