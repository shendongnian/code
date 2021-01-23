    var uri = new Uri("http://www.domain.com/path/to/page1.html?query=value#fragment");
    
    Console.WriteLine(uri.Scheme); // http
    Console.WriteLine(uri.Host); // www.domain.com
    Console.WriteLine(uri.AbsolutePath); // /path/to/page1.html
    Console.WriteLine(uri.PathAndQuery); // /path/to/page1.html?query=value
    Console.WriteLine(uri.Query); // ?query=value
    Console.WriteLine(uri.Fragment); // #fragment
    Console.WriteLine(uri.Segments[uri.Segments.Length - 1]); // page1.html
    
    for (var i = 0 ; i < uri.Segments.Length ; i++)
    {
    	Console.WriteLine("{0}: {1}", i, uri.Segments[i]);
    	/*
    	Output
    	0: /
    	1: path/
    	2: to/
    	3: page1.html
    	*/
    }
