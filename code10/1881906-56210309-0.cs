public static class LevelManager {
    public static void LoadLevel(string name)
    {
       print("Level loading requested for" + name);
       SceneManager.LoadScene(name);
    }
}
Used by doing `LevelManager.LoadLevel("MyLevel");`, but then you may question what is more effective, doing LevelManager.LoadLevel or SceneManager.LoadLevel, as they will do the exact same thing.
