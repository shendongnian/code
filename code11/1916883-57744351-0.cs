public class FileAction
{
  public string Old { get; set; }
  public string New { get; set; }
}
Usage:
// A step (item of list) consists of one to many rename actions
List<List<FileAction>> steps = new List<List<FileAction>>();
// ... fill list ...
// Handle steps
foreach (var step in steps)
{
  foreach (var action in step)
  {
    File.Move(action.Old, action.New);
  }
}
Adding a step to the list:
// Get Actions
var actions = new List<FileAction>
{
  new FileAction { Old = "old-file.txt", New = "new-file.txt" },
  new FileAction { Old = "old-file.js", New = "new-file.js" }
};
// Add to steps
steps.Add(actions);
Option 2
--------
Create a class for storing the actions **and** create a wrapping `Step` class
public class FileAction
{
  public string Old { get; set; }
  public string New { get; set; }
}
public class Step
{
  public List<FileAction> Actions { get; set; }
}
Usage:
List<Step> steps = new List<Step>();
// ... fill list ...
// Handle steps
foreach (var step in steps)
{
  foreach (var action in step.Actions)
  {
    File.Move(action.Old, action.New);
  }
}
Adding a step to the list:
// Get Actions
var actions = new List<FileAction>
{
  new FileAction { Old = "old-file.txt", New = "new-file.txt" },
  new FileAction { Old = "old-file.js", New = "new-file.js" }
};
// Create and add step
var step = new Step { Actions = actions };
steps.Add(step);
