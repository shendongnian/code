var dict = new Dictionary<int, bool>()
{
    {1, false},
    {2, false},
    {3, false},
    {4, false},
    {5, false},
    {6, false}
};
new List<int> { 1, 3, 4 }.ForEach(i => myObject1.dict[i] = true);
new List<int> { 3       }.ForEach(i => myObject2.dict[i] = true);
new List<int> { 1, 5    }.ForEach(i => myObject3.dict[i] = true);
