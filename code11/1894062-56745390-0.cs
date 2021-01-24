c#
private void ReadKey(){
        // Waits for getInput.Set()
        getInput.WaitOne();
        //The problem with this is the read keys stacking up
		// causing the need for a lot of keystrokes
		input = Console.ReadKey().KeyChar;
		gotInput.Set();
}
inside the class.
Make these
AutoResetEvent getInput, gotInput;
char input;
class variables and initialize them inside `Setup(){...}`
Finally call `Thread tom = new Thread(ReadKey);` where the new function is currently being made.
Note: This answer is not for best practice use, but will get a prototype to work.
