public static List<List<T>> ChunkBy<T>(List<T> source, int chunkSize) 
{
    var pages = new List<List<T>>();
    var page = new List<T>();
    var i = 0;
    foreach( var s in source ) {
        if((i++ % chunkSize) == 0 ) { page = new List<T>(); pages.Add(page);}
        page.Add(s);
    }
    return pages;
}
