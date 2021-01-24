    GameObject newGameObject = null;
    if (x > 3.14)
            {
                if (newGameObject != null && newGameObject.scene.IsValid())
                {
                    Destroy(newGameObject);
                    newGameObject = GameObject.Instantiate(object1);
                }
                else
                {
                    newGameObject = GameObject.Instantiate(object1);
                }
    
            }
    else
            {
                 Destroy(newGameObject);
            }
