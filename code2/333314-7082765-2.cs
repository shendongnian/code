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
    
