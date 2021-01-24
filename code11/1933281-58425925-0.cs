cs
public delegate void OnLongRunningOperationStartedEventHandler(object sender);
public delegate void OnLongRunningOperationFinishedEventHandler(object sender);
public event OnLongRunningOperationStartedEventHandler OnLongRunningOperationStarted;
public event OnLongRunningOperationFinishedEventHandler OnLongRunningOperationFinished;
private void LoadContactList() {
  OnLongRunningOperationStarted?.Invoke(this);
  LoadAllContactsInAThread(); /*Takes a long time*/
  OnLongRunningOperationFinished.Invoke(this);
}
And your main view model will hook-up to them like this:
**Main View Model**
cs
public bool LongRunningOperation { get; private set; }
// Keep track of the number of modules currently running long operations
private int _countLongRunningOperations = 0;
public LoadSubModules(){
	// Depending on how you load your sub modules, this piece of code could move around
	foreach (var module in submodules){
		module.OnLongRunningOperationStarted += Module_LongOperationStarted;
		module.OnLongRunningOperationFinished += Module_LongOperationFinished;
	}
}
private void Module_LongOperationStarted(object sender){
	_countLongRunningOperations += 1;
	LongRunningOperation = true;
}
private void Module_LongOperationFinished(object sender){
	_countLongRunningOperations -= 1;
	if (_countLongRunningOperations == 0) {
		LongRunningOperation = false;
	}
The same principle (using events) could be used to bubble up error messages from each submodule to the main view model.
