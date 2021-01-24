/// <summary>
/// Method called when a new dialog has been pushed onto the stack and is being activated.
/// </summary>
/// <param name="dc">The dialog context for the current turn of conversation.</param>
/// <param name="options">(Optional) additional argument(s) to pass to the dialog being started.</param>
/// <param name="cancellationToken">A cancellation token that can be used by other objects
/// or threads to receive notice of cancellation.</param>
/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
/// <remarks>If the task is successful, the result indicates whether the dialog is still
/// active after the turn has been processed by the dialog.</remarks>
public abstract Task<DialogTurnResult> BeginDialogAsync(DialogContext dc, object options = null, CancellationToken cancellationToken = default(CancellationToken));
This means to implement what you're looking for, you have 3 options: 
A) You pass the data in as part of DialogContext. This is easiest if the data is coming from the customer, as in it's the answer to a question your bot just asked, ie "How old are you?"
B) You save the data you need in a global variable in a previous dialog step and call it in the portion of the dialog you need. 
c) BeginDialogAsync is an abstract class. You could build your own child Dialog class, inherit this dialog class, and override the method.
