    var As = S.Select(x => x.A)
              .Where( x=> !string.IsNullOrEmpty(x))
              .Distinct();
    var Bs = S.Select(x => x.B)
              .Where( x=> !string.IsNullOrEmpty(x))
              .Distinct();
    var myArray = new[] { As, Bs }.SelectMany(x => x).ToArray();
