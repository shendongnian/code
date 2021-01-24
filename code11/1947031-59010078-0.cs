    public abstract class StepEditorControl : UserControl, IStepEditor
    {
        public abstract StepConfig Save();
        public abstract Load(StepConfig config);
    }
