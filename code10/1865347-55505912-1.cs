    public GameObject[] arrayofcookie;
    public void destroyCookie()
    {
        arrayofcookie= GameObject.FindGameObjectsWithTag("Cookie");
        for (int i = 0; i < arrayofcookie.Length; i++)
        {
            Destroy(arrayofcookie[i].gameObject);
        }
    }
