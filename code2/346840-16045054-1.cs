    private void SaveToIsolatedStorage()
    {
      saveToIsolatedStorage("GameData", GameData);
    }
    private void LoadFromIsolatedStorage()
    {
      Object temp;
      if (loadObject("GameData", out temp))
      {
        GameData = (CGameData)temp;
      }
      else
      {
        GameData.Reset();
      }
    }
