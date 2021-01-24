    if (PlayerPrefs.HasKey("meshName"))
        {
            Debug.Log("PlayerPrefs does have the key we are looking for and it is " + PlayerPrefs.GetString("meshName"));
            /// This is redundant you just set objName to the string earlier
            /// objName = PlayerPrefs.GetString("meshName");
            if (objName == PlayerPrefs.GetString("meshName"))
            {
                leMesh = Resources.Load<GameObject>(@"Models\" + objName);
            }
            else
            {
                /// And here you do it again, constantly trying to get that string
                /// In order to find the object, of course if the string doesnt exist
                /// youll simply get an unassigned referenceException on this line:
                /// change.GetComponent<MeshFilter>().mesh = leMesh.GetComponent<MeshFilter>().sharedMesh
                objName = PlayerPrefs.GetString("meshName");
                leMesh = Resources.Load<GameObject>(@"Models\" + objName);
            }
        }
