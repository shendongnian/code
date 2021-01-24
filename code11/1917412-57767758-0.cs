    public bool GlobalInvoke(System.ComponentModel.Design.CommandID commandID)
        {
            foreach(MenuCommand command in menuCommands)
            {
                if (command.CommandID == commandID)
                {
                    command.Invoke();
                    break;
                }
            }
    
            return false;
        }
