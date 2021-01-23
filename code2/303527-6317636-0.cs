    List<INeedInitialization> InitializedComponents = new List<INeedInitialization> {Fonts, Screens, Menus};
    List<INeedUpdating> UpdatedComponents = new List<INeedUpdating> {Screens, Menus}
    protected void Initialize(){
      foreach(var i in InitializedComponents)
        i.Initialize();
    }
    protected void Update(){
      foreach(var u in UpdatedComponents)
        u.Update();
    }
