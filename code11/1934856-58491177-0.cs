    Enemy Script.cs
    
    using UnityEngine.SceneManagement; // contains scenemanagement functions
    
    public GameObject[] enemies;
    
    void Update()
    {
    	enemeis = GameObject.FindGameObjectsWithTag("Enemy"); // checks if enemies are available with tag enemey note you should set this to your enemies in the inspector
    	if (enemeis.length ==0)
    	{
    		SceneManager.LoadScene("OtherSceneName"); // Load the scene with name "OtherSceneName"
    	}
    }
    
    Bullet Script.cs
    using UnityEngine.SceneManagement;
    
    void Update()
    {
    	if(remainingShots == -1)
    	{
    		SceneManager.LoadScene("OtherSceneName");
    	}
    }
