    private void Update()
    {
        Spawn(prefab, Vector3.forward); // or whatever forward direction makes sense.
    }
    public void Spawn(GameObject obj, Vector3 objForward)
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 tempVec = Vector3.zero;
            foreach (Vector3 vec3 in points)
            {
                if (Vector3.Distance(vec3, GetMousePos()) < Vector3.Distance(tempVec, GetMousePos()))
                    tempVec = vec3;
            }
            RaycastHit hit;
            if (Physics.Raycast(tempVec, Vector3.up, out hit, 1f))
            {
                print(hit.transform.gameObject);
                Quaternion rot = Quaternion.LookRotation(objForward, hit.normal);
                GameObject GO = Instantiate(obj, tempVec, rot);
            }
        }
    }
