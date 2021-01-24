c-sharp
private void deleteScene(DataContainers.Scene iScene) {
    // Get root database reference
    DatabaseReference mDatabase = FirebaseDatabase.DefaultInstance.RootReference;
    
    // Initialize a new list of "path->value" pairs
    Dictionary<string, Object> childUpdates = new Dictionary<string, Object>();
    
    // Delete the given scene and all of its models
    childUpdates["/Scenes/" + iScene.id] = null;
    foreach (var _model in iScene.models)
    {
        childUpdates["/models/" + _model] = null;
    }
    
    mDatabase.UpdateChildrenAsync(childUpdates);
}
