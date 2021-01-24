using System.Linq;
(...)
const string input = @"A/0/0.7
C/1/0/0.1 0.4
B/1/0/0.6 0.8
D/2/2 1/0.6 0.7 0.1 0.2"; 
static void Main(string[] args)
{
  // Write to file to imitate the scenario
  System.IO.File.WriteAllText("x.txt", input);
  
  var lines = System.IO.File.ReadAllLines("x.txt");
  var parsed = lines.Select( l => {
    var components = l.Split("/");
    var hasExtra = components.Length > 3;
    return new { 
      Name = components[0],
      // Omit StringSplitOptions.RemoveEmptyEntries for brevity
      Parents = components[hasExtra ? 2 : 1].Split(" ").Select(s => int.Parse(s)).ToArray(),
      Probabilities = components[hasExtra ? 3 : 2].Split(" ").Select(s => decimal.Parse(s)).ToArray() 
    };
    }).ToList(); // Execute the 'Select'
  var json = System.Text.Json.JsonSerializer.Serialize(
      value: parsed, 
      options: new System.Text.Json.JsonSerializerOptions() { WriteIndented = true });
  Console.WriteLine(json);
}
Output 
[
  {
    "Name": "A",
    "Parents": [
      0
    ],
    "Probabilities": [
      0.7
    ]
  },
  {
    "Name": "C",
    "Parents": [
      0
    ],
    "Probabilities": [
      0.1,
      0.4
    ]
  },
  {
    "Name": "B",
    "Parents": [
      0
    ],
    "Probabilities": [
      0.6,
      0.8
    ]
  },
  {
    "Name": "D",
    "Parents": [
      2,
      1
    ],
    "Probabilities": [
      0.6,
      0.7,
      0.1,
      0.2
    ]
  }
]
