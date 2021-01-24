csharp
class IDS
{
    
    #region Proprieties
    public int Id { get; set; }
    #endregion
    
    #region Lists
    public List<IDS> _ids = new List<IDS>();
    #endregion
}
Now, you'll need to link the class to the main, for that, go in your main code and put at the top :
csharp
using SolutionName.Folder;
Next go to your button event and simply put this:
csharp
private void btnAutoGen_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
{
   int iId = 0;
   
   try
   {
       var req = (from value in _id
                  select value.Id).Max() + 1;
       iId = req;
   }
   catch (InvalidOperationException)
   {
       iId = 1;
   }
You now have a button that auto increment.
