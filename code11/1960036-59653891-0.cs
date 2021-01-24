    public class ErrorWindowController : ErrorListProvider
    {
    #region Constructor
    /// <summary>
    /// Instance Constructor
    /// </summary>
    /// <param name="aServiceProvider"></param>
    public ErrorWindowController(IServiceProvider aIServiceProvider) : base(aIServiceProvider)
    {
    }
    #endregion
    #region Public Methods
    // Use this to add a collection of custom errors in VS Error List
    public void AddErrors(IEnumerable<ErrorModel> aErrors)
    {
        SuspendRefresh();
        foreach (ErrorModel error in aErrors)
        {
          ErrorTask errorTask = new ErrorTask
          {
            ErrorCategory = error.Category,
            Document = error.FilePath,
            Text = error.Description,
            Line = error.Line - 1,
            Column = error.Column,
            Category = TaskCategory.BuildCompile,
            Priority = TaskPriority.High,
            HierarchyItem = error.HierarchyItem
          };
          errorTask.Navigate += ErrorTaskNavigate;
          Tasks.Add(errorTask);
        }
        BringToFront();
        ResumeRefresh();
    }
    // Remove all the errors from Error List which are depending of a project and this specific project is closed
    // Or remove all the errors from Error List when the VS solution is closed
    public void RemoveErrors(IVsHierarchy aHierarchy)
    {
        SuspendRefresh();
        for (int i = Tasks.Count - 1; i >= 0; --i)
        {
          var errorTask = Tasks[i] as ErrorTask;
          aHierarchy.GetCanonicalName(Microsoft.VisualStudio.VSConstants.VSITEMID_ROOT, out string nameInHierarchy);
          errorTask.HierarchyItem.GetCanonicalName(Microsoft.VisualStudio.VSConstants.VSITEMID_ROOT, out string nameErrorTaskHierarchy);
          if (nameInHierarchy == nameErrorTaskHierarchy)
          {
            errorTask.Navigate -= ErrorTaskNavigate;
            Tasks.Remove(errorTask);
          }
        }
        ResumeRefresh();
    }
    // Remove all the errors from the Error List
    public void Clear()
    {
        Tasks.Clear();
    }
    #endregion
    #region Private Methods
    // This is optional
    // Add navigation for your errors. 
    private void ErrorTaskNavigate(object sender, EventArgs e)
    {
      ErrorTask objErrorTask = (ErrorTask)sender;
      objErrorTask.Line += 1;
      bool bResult = Navigate(objErrorTask, new Guid(EnvDTE.Constants.vsViewKindCode));
      objErrorTask.Line -= 1;
    }
    #endregion
    }
