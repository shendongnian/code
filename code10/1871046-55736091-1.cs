    public class DumbbellExercise
    {
        List<DumbbellDataValue> dumbbellData = new List<DumbbellDataValue>();
        public void AddToolData(ToolData toolData)
        {
            if (toolData is DumbbellDataValue)
                this.dumbbellData.Add((DumbbellDataValue)toolData);
        }
    }
