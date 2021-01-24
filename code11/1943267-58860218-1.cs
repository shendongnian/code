``csharp
for (int i = 1; i <= 7; i += (i == 5 || i == 2) ? 2 : 1)
{
    Console.Write(i);
}
// Output: 12457
for (int i = 1; i <= 7; i = i switch { 1=>2, 2=>4, 4=>5, 5=>7, 7=>8})
{
    Console.Write(i);
}
// Output: 12457
``
Or even something really silly like a self indexing lookup:
``csharp
for (int i = 1; i <= 7; i += new[] {0,1,2,0,1,2,0,1}[i])
{
    Console.Write(i);
}
// Output: 12457
``
