    GrabBody(ParserTools.OpenM12Parser(_response.BodyBytes));
    
    public static HTMLparser OpenM12Parser(byte[] buffer)
    {
        HTMLparser parser = new HTMLparser();
        parser.SetChunkHashMode(false);
        parser.bKeepRawHTML = false;
        parser.bDecodeEntities = true;
        parser.bDecodeMiniEntities = true;
    
        if (!parser.bDecodeEntities && parser.bDecodeMiniEntities)
            parser.InitMiniEntities();
    
        parser.bAutoExtractBetweenTagsOnly = true;
        parser.bAutoKeepScripts = true;
        parser.bAutoMarkClosedTagsWithParamsAsOpen = true;
        parser.CleanUp();
        parser.Init(buffer);
        return parser;
    }
    
    public void GrabBody(HTMLparser parser)
    {
    
        // parser will return us tokens called HTMLchunk -- warning DO NOT destroy it until end of parsing
        // because HTMLparser re-uses this object
        HTMLchunk chunk = null;
    
        // we parse until returned oChunk is null indicating we reached end of parsing
        while ((chunk = parser.ParseNext()) != null)
        {
            switch (chunk.oType)
            {
                // matched open tag, ie <a href="">
                case HTMLchunkType.OpenTag:
                    if (chunk.sTag == "body")
                    {
                        // Start generating the DOM node (as shown in the previous example link)
                    }
                    break;
    
                // matched close tag, ie </a>
                case HTMLchunkType.CloseTag:
                    break;
    
                // matched normal text
                case HTMLchunkType.Text:
                    break;
    
                // matched HTML comment, that's stuff between <!-- and -->
                case HTMLchunkType.Comment:
                    break;
            };
        }
    }
