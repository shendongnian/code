    public class FileCopySubTask
    {
        public void Execute(DataContext context)
        {
            context.Progress.OnFileCopied(new FileOperationEventArgs("c:/temp1", "c:/temp2"));
        }
    }
