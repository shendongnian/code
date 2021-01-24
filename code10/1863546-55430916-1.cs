private void DoYourThing()
{
    try
    {
        // Do your code here
    }
    catch( Exception _Exception )
    {
        MessageBox.Show( _Exception .Message );
        DoYourThing( ); // Reloop the code if any error happend.
    }
}
