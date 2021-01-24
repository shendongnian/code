    public class CommandBuilder
    {
        public class internalCommandBuilder
        {
            private string Action = "";
            private string ID = "";
            private string NewText = "";
            private string Type = "";
            private Commands.CommandsEnum enumResult;
            public internalCommandBuilder WithAction(string action)
            {
                Action = action;
                return this;
            }
            public internalCommandBuilder WithID(string id)
            {
                ID = id;
                return this;
            }
            public internalCommandBuilder WithNewText(string newText)
            {
                NewText = newText;
                return this;
            }
            public internalCommandBuilder WithType(string type)
            {
                Type = type;
                return this;
            }
            /// <summary>
            /// Todo: document this
            /// </summary>
            /// <param name="command"></param>
            /// <returns></returns>
            public DataFormatter Build(string command)
            {
                Enum.TryParse<Commands.CommandsEnum>(command, out enumResult);
                Command cmd2 = new Command(enumResult);
                DataFormatter df2 = new DataFormatter();
                df2._Command = cmd2;
                Subcommand scmd2 = new Subcommand();
                scmd2.Action = Action;
                scmd2.ID = ID;
                scmd2.NewValueString = NewText;
                scmd2.Type = Type;
                df2._Subcommand = scmd2;
                Action = "";
                ID = "";
                NewText = "";
                Type = "";
                return df2;
            }
        }
        public static internalCommandBuilder WithAction(string action)
        {
            return new internalCommandBuilder().WithAction(action);
        }
        public static internalCommandBuilder WithID(string id)
        {
            return new internalCommandBuilder().WithID(id);
        }
        public static internalCommandBuilder WithNewText(string newText)
        {
            return new internalCommandBuilder().WithNewText(newText);
        }
        public static internalCommandBuilder WithType(string type)
        {
            return new internalCommandBuilder().WithType(type);
        }
        public CommandBuilder()
        {
        }
    }
