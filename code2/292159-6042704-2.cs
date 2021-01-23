    IStateContainer response = null;
    using (MemoryStream memData = new MemoryStream())
    {
        using (StreamWriter writer = new StreamWriter(memData))
        {
            writer.Write(state.stateobject);
            writer.Flush();
            memData.Flush();
            SoapFormatter formatter = new SoapFormatter();
            memData.Position = 0;
            response = (IStateContainer)formatter.Deserialize(memData);
        }
    }
