public class saveLoadSystem
{
    public void LoadWorld()
    {
        //Your code
    }
    private void SaveWorld()
    {
        //Your Code
    }
    private void SaveInstalledObjects()
    {
        //Your code
    }
    private void SaveUnits()
    {
        //Your code
    }
    public void Save()
    {
        this.SaveWorld();
        this.SaveInstalledObjects();
        this.SaveUnits();
    }
}
public class Main
{
    public void OnStart()
    {
        //You can call your save and load method like this 
        var saveLoadSystem = new saveLoadSystem();
        saveLoadSystem.Save();
        saveLoadSystem.LoadWorld();
    }
}
