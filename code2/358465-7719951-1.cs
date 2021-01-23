    public void KeyCommandFactory{
       private static Map<string,Type> Mappings;
       private static KeyCommandFactory(){
          /* Example */
          Mappings.Add("PlayMusic",typeof(PlayMusicCommand));
          Mappings.Add("AnimateFrame",typeof(AnimateFrameCommand));
          Mappings.Add("StopFrame",typeof(StopFrameCommand));
       }
       public static GetKeyCommand(IKeyCommandInfo info){
          return (IKeyCommandInfo)Activator.CreateInstance(Mappings[info.CommandName]); // Add this property
       }
    }
