    [ScriptableMember()]
        public string setCommand(string commandValue, string argsValue)
        {
            commands.Enqueue(commandValue);
            args.Enqueue(argsValue);
            commandWaitingFlag = true;
            return Application.Current.HasElevatedPermissions.ToString();
        }
