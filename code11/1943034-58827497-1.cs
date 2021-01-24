switch (OrgPath.Count)
{
    case 1:
        budgetRequest.Level1NodeId = OrgPath[1].LevelNodeId;
may need to be changed to 
switch (OrgPath.Count)
{
    case 1:
        budgetRequest.Level1NodeId = OrgPath[0].LevelNodeId;
# A. If BudgetRequest can be changed
The budget request class could store the level node ids in a collection. 
Consider the following snippet.
class BudgetRequest {
    public int[] LevelNodeIds {get; set;}
}
(...)
var budgetRequest = new BudgetRequest() 
{
    LevelNodeIds = new int[OrgPath.Count]
};
for(int i = 0; i < OrgPath.Count; i++) {
    budgetRequest.LevelNodeIds[i] = OrgPath[i].LevelNodeId;
}
# B. If BudgetRequest cannot be changed.
@p-s-w-g's `if` solution is the way to go, but it's possible to make the code look nicer and keep the `switch`. 
(Please note I for level 7 I used OrgPath[6], because of zero-based indexes, you may adjust this)
switch (OrgPath.Count)
{
    case 7: budgetRequest.Level7NodeId = OrgPath[6].LevelNodeId; goto case 6;
    case 6: budgetRequest.Level6NodeId = OrgPath[5].LevelNodeId; goto case 5;
    case 5: budgetRequest.Level5NodeId = OrgPath[4].LevelNodeId; goto case 4;
    case 4: budgetRequest.Level4NodeId = OrgPath[3].LevelNodeId; goto case 3;
    case 3: budgetRequest.Level3NodeId = OrgPath[2].LevelNodeId; goto case 2;
    case 2: budgetRequest.Level2NodeId = OrgPath[1].LevelNodeId; goto case 1;
    case 1: budgetRequest.Level1NodeId = OrgPath[0].LevelNodeId; break;
    default: goto case 7;
}
Example
var OrgPath = new[]{
    new { LevelNodeId = "A1" },
    new { LevelNodeId = "B2" },
    new { LevelNodeId = "C3" },
    new { LevelNodeId = "D4" },
    new { LevelNodeId = "E5" },
    new { LevelNodeId = "F6" },
    new { LevelNodeId = "G7" },
    new { LevelNodeId = "H8" },
}.ToList();
var budgetRequest = new BudgetRequest();
switch (OrgPath.Count)
{
    case 7: budgetRequest.Level7NodeId = OrgPath[6].LevelNodeId; goto case 6;
    case 6: budgetRequest.Level6NodeId = OrgPath[5].LevelNodeId; goto case 5;
    case 5: budgetRequest.Level5NodeId = OrgPath[4].LevelNodeId; goto case 4;
    case 4: budgetRequest.Level4NodeId = OrgPath[3].LevelNodeId; goto case 3;
    case 3: budgetRequest.Level3NodeId = OrgPath[2].LevelNodeId; goto case 2;
    case 2: budgetRequest.Level2NodeId = OrgPath[1].LevelNodeId; goto case 1;
    case 1: budgetRequest.Level1NodeId = OrgPath[0].LevelNodeId; break;
    default: goto case 7;
}
Console.WriteLine(System.Text.Json.JsonSerializer.Serialize(budgetRequest, new System.Text.Json.JsonSerializerOptions{WriteIndented = true}));   
Output
{
  "Level1NodeId": "A1",
  "Level2NodeId": "B2",
  "Level3NodeId": "C3",
  "Level4NodeId": "D4",
  "Level5NodeId": "E5",
  "Level6NodeId": "F6",
  "Level7NodeId": "G7"
}
