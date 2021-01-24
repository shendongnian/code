    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player") && counter.text == "X 3")
        {
            StartCoroutine(SceneLoadWithDelay(sceneNumber, 4));
        }
    }
	
	IEnumerator SceneLoadWithDelay(int sceneNum, int numSeconds)
	{
		yield return new WaitForSeconds(numSeconds);
		
		SceneManager.LoadScene (sceneNum);
	}
