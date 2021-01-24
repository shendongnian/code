    [MenuItem("GameObject/Generate as Pickup Item", false, 30)]
    public static void GeneratePickupItems()
    {
        if (Selection.gameObjects.Length > 0)
        {
            pickeditems.Clear();
            for (int i = 0; i < Selection.gameObjects.Length; i++)
            {
                if (Selection.gameObjects[i].GetComponent<Whilefun.FPEKit.FPEInteractablePickupScript>() == null)
                {
                    Selection.gameObjects[i].AddComponent<BoxCollider>();
                    Selection.gameObjects[i].AddComponent<Whilefun.FPEKit.FPEInteractablePickupScript>();
                }
                Selection.gameObjects[i].layer = 9;
                Selection.gameObjects[i].tag = "Pickup Item";
                pickeditems.Add(Selection.gameObjects[i]);
            }
            picked = true;
        }
    }
    
