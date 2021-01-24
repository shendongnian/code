public GameObject parent;
private GameObject AssignedChild;
 foreach (Transform eachChild in parent.GetComponentsInChildren<Transform>())
        {
            if (eachChild.gameObject.tag == "TagOfTheObject")
            {
               //assign the tagged GameObject to "AssignedChild" GameObject
               AssignedChild = eachChild.gameObject;
            }
        }
