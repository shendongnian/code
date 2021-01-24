cs
void Start()
{
    allObjects = FindObjectsOfType<GameObject>().ToList();
    foreach (GameObject go in allObjects)
    {
        var colliders = go.transform.GetComponents<Collider>();
        int length = colliders.Length;
        if (length == 0)
        {  
            Debug.Log(string.Format("{0} - No Colliders", go.name));
        }
        else
        {
            //composes a list of the colliders types, this will print what you want e.g. "Wall1 - BoxCollider, MeshCollider"
    
            string colliderTypes = string.Empty;
            for (int i = 0; i < length; i++)
            {
                colliderTypes = string.Format("{0}{1}", colliderTypes, colliders[i].GetType().Name);
                if (i != (length - 1))
                {
                    colliderTypes = string.Format("{0}, ", colliderTypes);
                }
            }
            Debug.Log(string.Format("{0} - {1}", go.name, colliderTypes));
        }
    }
}
Note that the `Collider` class is the base of 3D colliders, if you will also need to check for 2D ones then get all `Collider2D` components and do the same thing.
