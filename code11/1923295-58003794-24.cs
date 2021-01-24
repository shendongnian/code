    // If you make this of type SpriteController the Inspector automatically
    // references the correct component and you can get rid of the GetComponent call later
    public SpriteController testingCardCOntainerGameObject;
    var testingCardObjectInstance = Instantiate(testingCardCOntainerGameObject, testingContainerCoords, Quaternion.identity); 
    // for testing use 1 since 0 is the default for int ;)
    testingCardObjectInstance.SpriteIndex = 1;
    NetworkServer.Spawn(testingCardObjectInstance);
 
