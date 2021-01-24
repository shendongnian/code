        private void AddDescendantsWithTag(Transform parent, List<GameObject> list)
    {
        foreach (Transform child in parent)
        {
            if (child.gameObject.GetComponent<MeshRenderer>() != null
                && child.gameObject.GetComponent<Collider>()) // You can modify this line according to your requirement. 
            {
                list.Add(child.gameObject);
            }
            AddDescendantsWithTag(child, list);
        }
    }
