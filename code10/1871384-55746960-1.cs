List<Form> FormHistory = new List<Form>( );
public static Form StaticForm;
private void UpdateDashBoardForm(Form myform)    //use to get form and add to panel
{
    FormHistory.Add( StaticForm );
    // Plus Your code.
}
private void GoBackToPreviousForm()
{
    if( FormHistory.Count > 0 )
    {
        // Plus what ever you need to do to go to the next form.
        FormHistory[ FormHistory.Count - 1 ].Show( );
        FormHistory.RemoveAt( FormHistory.Count - 1 );
    }
    else
    {
        // You are at the first loaded form.
    }
}
