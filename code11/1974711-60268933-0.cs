 CSharp
Globals.ThisAddIn.Application.DeleteCustomList(Globals.ThisAddIn.Application.GetCustomListNum(new string[] { "China", "Taiwan" }));
Here is the same, a bit simpler but also longer:  
 CSharp  
// get an application object
Excel.Application xlApp = Globals.ThisAddIn.Application;
// assign the list you want to remove to an array
string[] myList = new string[] { "China", "Taiwan" };
// get the number of your list from Excel application
int listNum = xlApp.GetCustomListNum(myList);
// delete the list by its number - it's the only way to delete 
// a custom list that I've found
xlApp.DeleteCustomList(listNum);
