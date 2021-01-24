C#
using(var myProcess = new Process()) {
    ...
    myProcess.Start();
    myProcess.StandardInput.WriteLine("y"); // Write 'y' to the processes' console input
    ...
}
Note: This approach is not very reusable.
Using a command line option like `/no-confirm` (as John Wu suggested in the questions comments) is preferable, if it exists.
