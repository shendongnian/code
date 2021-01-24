void Main()
{
    var people = LeesPersoon();
    for (var i = 0; i < people.Length; i++)
    {
        PrintPerson(people[i]);
    }
}
void PrintPerson(Persoon p)
{
    Console.Write("\n");
    Console.Write(p.FirstName + " " + p.SecondName + " ");
    PrintGeslacht(p.Gender);
    Console.Write("\n");
    Console.WriteLine("{0} jaar, {1}", p.Age, p.Residence);
}
Persoon[] LeesPersoon()
{
     Persoon[] personen = new Persoon[3];
     for (int i = 0; i < personen.Length; i++)
     {
          personen[i].FirstName = LeesString("Enter first name: ");
          personen[i].SecondName = LeesString("Enter second name: ");
          personen[i].Residence = LeesString("Enter residence: ");
          personen[i].Age = LeesInt("Enter age: ", 0, 120);
          personen[i].Gender = LeesGeslacht("Enter gender (m/f): ");
          //Console.Write("\n");
     }
     return personen;
}
