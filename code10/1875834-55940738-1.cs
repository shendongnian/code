    using System.Linq;
    
    ...
    
    var matches = TriangleRegistry.Where(t => t.Value.X1 == ... && t.Value.Y1 == ...); // fill in the blanks here with whatever you're looking for
    foreach (var match in matches)
    {
       Console.WriteLine("Here's a match: {0}", match.Selected);
    }
