string json = ""
public void SaveWorld()
 {
 json = json + JsonConvert.SerializeObject(worldToSave, Formatting.Indented, new JsonSerializerSettings 
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
