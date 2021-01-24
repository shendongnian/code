    static void Main( string[] args )
    {
        var source = new List<Csv1Data> {
            new Csv1Data { Code = 1, S1 = "A", Col5 = "a", Col6 = "b", Col7 = "c", Col8 = "d" },
            new Csv1Data { Code = 2, S1 = "B", Col5 = "a", Col6 = "b", Col7 = "c", Col8 = "d" },
        };
        var output = Map( source );
        XmlSerializer ser = new XmlSerializer( typeof( ExportModels.Xml1.Section ) );
        using ( var stream = new MemoryStream() )
        {
            using ( var writer = new StreamWriter( stream, Encoding.UTF8 ) )
            {
                ser.Serialize( writer, output );
            }
            var bytes = stream.ToArray();
            var str = Encoding.UTF8.GetString( bytes );
            Console.WriteLine( str );
        }
    }
