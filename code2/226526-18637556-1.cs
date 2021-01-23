    protected override void OnCustomCommand(int command)
        {
          switch (command)
          {
            case 128:
              eventLog1.WriteEntry("Command " + command + " successfully called.");
              break;
            default:
              break;
          }
        }
