    Enemy Script.cs
    
    using UnityEngine.SceneManagement; // Contains scene management functions
    
    public GameObject[] enemies;
    
    void Update()
    {
    	enemies = GameObject.FindGameObjectsWithTag("Enemy"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
    	if (enemies.length == 0)
    	{
    		SceneManager.LoadScene("OtherSceneName"); // Load the scene with name "OtherSceneName"
    	}
    }
    
    Bullet Script.cs
    using UnityEngine.SceneManagement;
    
    void Update()
    {
    	if (remainingShots == -1)
    	{
    		SceneManager.LoadScene("OtherSceneName");
    	}
    }
