    public static class MyExtensionsClass {
    
       // extension methods here
        public static TitleInfoPacket GenerateTitInfo(this ICharacterDAO 
     visualEntity)
        {
          var visibleTitle = visualEntity.Titles.FirstOrDefault(s => s.Visible)?.TitleType;
          var effectiveTitle = visualEntity.Titles.FirstOrDefault(s => s.Active)?.TitleType;
    return new TitleInfoPacket
        {
            VisualId = visualEntity.VisualId,
            EffectiveTitle = effectiveTitle ?? 0,
            VisualType = visualEntity.VisualType,
            VisibleTitle = visibleTitle ?? 0,
        };
      }
    }
