    public void LevelComplete() {
        DatabaseCode.writeDatabase(SceneManager.GetActiveScene().buildIndex + 1, counter);
        DatabaseCode.ReadFromDb(SceneManager.GetActiveScene().buildIndex + 1, (result) => {
            Debug.Log("result " + result.ToString());
            prevscore = result;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });    
    }
