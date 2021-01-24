C#
using(var myProcess = new Process()) {
    ...
    myProcess.StandardInput.WriteLine("y"); // Write 'y' to the processes' console input
    myProcess.Start();
    ...
}
Note: This approach is not very reusable.
Using a command line option like `/no-confirm` (as John Wu suggested in the questions comments) is preferable, if it exists.
