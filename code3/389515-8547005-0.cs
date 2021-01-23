    private void ImportTasks()
    {
        ObservableCollection<PrestoCommon.Entities.LegacyPresto.TaskBase> taskBases = new ObservableCollection<PrestoCommon.Entities.LegacyPresto.TaskBase>();
        string filePathAndName = GetFilePathAndNameFromUser();
        if (string.IsNullOrWhiteSpace(filePathAndName)) { return; }
        using (FileStream fileStream = new FileStream(filePathAndName, FileMode.Open))
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<PrestoCommon.Entities.LegacyPresto.TaskBase>));
            taskBases = xmlSerializer.Deserialize(fileStream) as ObservableCollection<PrestoCommon.Entities.LegacyPresto.TaskBase>;
        }
        int sequence = 1;
        foreach (PrestoCommon.Entities.LegacyPresto.TaskBase legacyTask in taskBases)
        {
            TaskBase task = CreateTaskFromLegacyTask(legacyTask);
            task.Sequence = sequence;
            this.SelectedApplication.Tasks.Add(task);
            sequence++;
        }            
        ApplicationLogic.Save(this.SelectedApplication);
        NotifyPropertyChanged(() => this.SelectedApplicationTasks);
    }
    [SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "PrestoCommon.Misc.LogUtility.LogWarning(System.String)")]
    private static TaskBase CreateTaskFromLegacyTask(PrestoCommon.Entities.LegacyPresto.TaskBase legacyTask)
    {
        Debug.WriteLine(legacyTask.GetType().ToString());
        TaskBase task = null;
        string legacyTaskTypeName = legacyTask.GetType().Name;
        switch (legacyTaskTypeName)
        {
            case "TaskCopyFile":
                task = TaskCopyFile.CreateNewFromLegacyTask(legacyTask);
                break;
            case "TaskDosCommand":
                task = TaskDosCommand.CreateNewFromLegacyTask(legacyTask);
                break;
            case "TaskXmlModify":
                task = TaskXmlModify.CreateNewFromLegacyTask(legacyTask);
                break;
            default:
                LogUnexpectedLegacyTask(legacyTaskTypeName);
                break;
        }
