    var testingCardObjectInstance = Instantiate(testingCardCOntainerGameObject, testingContainerCoords, Quaternion.identity); 
    // for testing use 1 since 0 is the default for int ;)
    testingCardObjectInstance.GetComponnet<SpriteController>().SpriteIndex = 1;
    NetworkServer.Spawn(testingCardObjectInstance);
 
