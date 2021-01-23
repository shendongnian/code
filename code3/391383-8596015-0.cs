    "crabapple"
        .OrderBy(c => { Console.Write(c); return c; })
        .Where(c => { Console.Write(c); return c > 'c'; })
        .Count();
    "crabapple"
        .Where(c => { Console.Write(c); return c > 'c'; })
        .OrderBy(c => { Console.Write(c); return c; })
        .Count();
