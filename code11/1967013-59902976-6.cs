public void SaveWorld(World worldToSave)
{
   SaveSystem.Init(); 
   string json = JsonConvert.SerializeObject(worldToSave, Formatting.Indented, new JsonSerializerSettings { 
      TypeNameHandling = TypeNameHandling.Auto,
      PreserveReferencesHandling = PreserveReferencesHandling.Objects 
   });
   File.AppendAllText(SaveSystem.SAVE_FOLDER + "/Save.json", json);
 }
void Save()
 { 
File.Delete(SaveSystem.SAVE_FOLDER + "/Save.json", json);
saveLoadSystem.SaveWorld(worldHandler.World);
saveLoadSystem.SaveInstalledObjects(worldHandler.installedObjectList);
saveLoadSystem.SaveUnits(unitHandler.unitList);  
}
   Second option: Use your string json variable at the top. And use only this variable at each method. Don't use different  variable for json. At each method append to json variable whatever you want. And use WriteAllText() method in your Save method only once not in your others method again and again.
string json = ""
public void SaveWorld() {
 string world = JsonConvert.SerializeObject(worldToSave, Formatting.Indented, new JsonSerializerSettings {
        TypeNameHandling = TypeNameHandling.Auto,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    });
json = json + world
} 
public void SaveInstalledObjects() {
string objects = "some objects" 
 json = json + objects
} 
public void SaveUnits() {
string units = "some units" 
 json = json + units
} 
void Save() {
saveLoadSystem.SaveWorld(worldHandler.World);
 saveLoadSystem.SaveInstalledObjects(worldHandler.installedObjectList);
 saveLoadSystem.SaveUnits(unitHandler.unitList); 
File.WriteAllText(SaveSystem.SAVE_FOLDER + "/Save.json", json);
}
