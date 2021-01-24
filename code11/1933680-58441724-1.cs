    foreach (GameObject go in allObjects)
    {
        print (go + " has:");
        foreach (Collider collider in go.transform.GetComponents<Collider>())
        {
            if(collider.GetType() == typeof(MeshCollider)) print("mesh");
            else if(collider.GetType() == typeof(BoxCollider)) print("box");
            else if(collider.GetType() == typeof(CapsuleCollider)) print("capsule");
            else if(collider.GetType() == typeof(SphereCollider)) print("sphere");
            else print("other");
        }
    }
