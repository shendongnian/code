    class YourClass: MonoBehaviour 
    {
        GameObject newGameObject
        void SomeMethod 
        {
            Destroy(newGameObject);
            //Then here just set the class level property
            newGameObject = GameObject.Instantiate(object1);
        }
    }
