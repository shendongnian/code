private void DoYourThing()
{
    try
    {
        // Do your code here
    }
    catch( Exception e )
    {
        MessageBox.Show( e.Message );
        DoYourThing( ); // Reloop the code if any error happend.
    }
}
