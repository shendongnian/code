    public IEnumerator panelfadewhite()
    {
        float ElapsedTime = 0f;
        float TotalTime = 2f;
        while (ElapsedTime < TotalTime)
        {
              ElapsedTime += Time.deltaTime;
              panel.color = Color.Lerp(new Color(1.0f, 1.0f, 1.0f, 0), new Color(1.0f, 1.0f, 1.0f, 1), (ElapsedTime / TotalTime));
              yield return null;
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("selection_ui", LoadSceneMode.Single);
        yield return null;    
    }
