public class ProgressData
{
    public int Value { get; set; }
    public int Maximum { get; set; }
}
public void ReportProgress(ProgressData progressData) 
{
   progressBar.Value = progressData.Value;
   progressBar.Maximum = progressData.Maximum
}
IProgress<ProgressData> progress = new Progress<ProgressData>(ReportProgress);
int result = await Task.Run(() => Method(progress));
and 
private int Method(IProgress<ProgressData> progress) {
    ...
    progress.Report(new ProgressData { Value = 1, Maximum = 10 });
    ...
}
From https://social.technet.microsoft.com/wiki/contents/articles/19020.progress-of-a-task-in-c.aspx
