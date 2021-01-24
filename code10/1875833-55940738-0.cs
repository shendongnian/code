    using System.Linq;
    
    ...
    
    var matches = TriangleRegistry.Where(t => t.X1 == ... && t.Y1 == ...); // fill in the blanks here with whatever you're looking for
    foreach (var match in matches)
    {
       Console.WriteLine("Here's a match: {0}", match.Selected);
    }
