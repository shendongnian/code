 c#
for (int i = 0; i < posAr_ItemManager.GetLength(0); i++)
{
    for (int j = 0; j < posAr_ItemManager.GetLength(1); j++)
    {
        for (int z = 0; z < posAr_ItemManager.GetLength(2); z++)
look very carefully at the middle tests. Also, consider hoisting the `GetLength` tests so you only do them once per dimension. Perhaps:
 c#
int rows = posAr_ItemManager.GetLength(0), columns = posAr_ItemManager.GetLength(1),
    categories = posAr_ItemManager.GetLength(2);
for (int row = 0; row < rows; row++)
{
    for (int col = 0; col < columns; col++)
    {
        for (int cat = 0; cat < categories; cat++)
