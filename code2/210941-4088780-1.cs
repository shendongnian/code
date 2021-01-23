            ParserRepository parserRepository = new ParserRepository();
            // ...
            IParser<MyObjectA> parserForMyObjectA = parserRepository.GetParser<MyObjectA>();
            IParser<MyObjectB> parserForMyObjectB = parserRepository.GetParser<MyObjectB>();
            using (var fs = new FileStream(@"file.ext", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                BinaryReader br = new BinaryReader(fs);
                MyObjectA objA = parserForMyObjectA.Read(br);
                MyObjectB objB = parserForMyObjectB.Read(br);
                // ...
            }
            // Notice that this code does not explicitly reference the MyObjectAParser or MyObjectBParser classes.
