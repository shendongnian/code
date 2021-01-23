    public bool ForceSoftwareRendering 
    {
        get 
        { 
            int renderingTier = (System.Windows.Media.RenderCapability.Tier >> 16);
            return renderingTier == 0;
        }
    }
