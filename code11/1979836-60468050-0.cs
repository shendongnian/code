c#
// int[] rooms; is defined at the top of the class
public void vacateOneRoom()
{
     Console.WriteLine("Which room is being vacated");
     // simple, error prone solution
     rooms[Convert.ToInt32(Console.ReadLine()) + 1] = 0; 
}
