    BuildAction action = null; //(BuildAction)actionType.Assembly.CreateInstance(actionType.FullName, true, System.Reflection.BindingFlags.CreateInstance, null, new object[] { subReader, format }, null, null);
    switch (actionType.Name) {
    case "SetVariable":
        action = new Actions.SetVariable((XmlReader)subReader, format);
        break;
    case "DisplayMessage":
        action = new Actions.DisplayMessage((XmlReader)subReader, format);
        break;
    }
