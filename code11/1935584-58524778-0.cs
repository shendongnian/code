     public static class DialogControlService<DialogType>
    {
        public static DialogResult DesiredDialogResult { get; set; }
        public static dynamic Attribute { get; set; }
        static DialogControlService()
        {
            DialogControlRegistrationService.Register(typeof(DialogType));
        }
    }
    public static class DialogControlRegistrationService
    {
        public static List<Type> RegisteredTypes { get; private set; }
        public static void Register(dynamic type)
        {
            RegisteredTypes.Add(type);
        }
        static DialogControlRegistrationService()
        {
            RegisteredTypes = new List<Type>();
        }
    }
