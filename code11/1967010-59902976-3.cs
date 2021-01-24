string json = ""
public void SaveWorld()
 {
 string world = JsonConvert.SerializeObject(worldToSave, Formatting.Indented, new JsonSerializerSettings {
        TypeNameHandling = TypeNameHandling.Auto,
        PreserveReferencesHandling = PreserveReferencesHandling.Objects
    });
json = json + world
} 
public void SaveInstalledObjects()
 {
string objects = "some objects" 
 json = json + objects
} 
public void SaveUnits()
 {
string units = "some units" 
 json = json + units
} 
void Save() {
saveLoadSystem.SaveWorld(worldHandler.World);
 saveLoadSystem.SaveInstalledObjects(worldHandler.installedObjectList);
 saveLoadSystem.SaveUnits(unitHandler.unitList); 
File.WriteAllText(SaveSystem.SAVE_FOLDER + "/Save.json", json);
}
}
