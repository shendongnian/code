    public void KeyCommandFactory: IKeyFrameCommandFactory
    {
        private static Map<Type, Type> mappings;
        public IKeyCommand GetKeyCommand(IKeyCommandInfo info)
        {
            Type infoType = info.GetType();
            return Activator.CreateInstance(mappings[infoType], info);
        }
    }
