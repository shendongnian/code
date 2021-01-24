static void other()
{
    var names = new[] { "OKO.pdf", "OKO.ZOKO.pdf", "aaa.frx", "bbb.TXT", "xyz.dbf", "abc.pdf" };
    var x = names.GroupBy(n => n.Split('.').Last());
    x.ToList().ForEach(g => WriteLine($"There are {g.Count()} files with extension '{g.Key}'"));
}
// Output:
//    There are 3 files with extension 'pdf'
//    There are 1 files with extension 'frx'
//    There are 1 files with extension 'TXT'
//    There are 1 files with extension 'dbf'
