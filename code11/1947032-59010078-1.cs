    public abstract class StepEditorControl : UserControl, IStepEditor
    {
        public abstract void Load(StepConfig config);
        public abstract StepConfig Save();
    }
