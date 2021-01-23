    static readonly string Remove = "Remove";
    static readonly string Keep = "Keep";
    static readonly string Add = "Add";
    var result = Concat
    (
        old.Except(new).Select(x => new { x, Remove }), 
        old.Intersect(new).Select(x => new { x, Keep }), 
        new.Except(old).Select(x => new { x, Add })
    );
