    // This would be better as a class variable rather then a local variable
    string meshName = PlayerPrefs.GetString("meshName", "Sphere");  
    // Skipping point B because it is redundant
    leMesh = Resources.Load<GameObject>(@"Models\" + meshName);  // Is this a GameObject or is it a Mesh???
    
    MeshFilter leMeshFilter = leMesh.GetComponent<MeshFilter>();
    if(leMeshFilter != null)
    {
        foreach (GameObject change in lesnek)
        {
            MeshFilter meshFilter = change.GetComponent<MeshFilter>();
            if(meshFilter != null)
            {
                meshFilter.mesh = leMeshFilter.sharedMesh;
            }
            else
            {
                meshFilter = change.AddComponent<MeshFilter>();
                meshFilter.mesh = leMeshFilter.sharedMesh;
            }
        }
    }
