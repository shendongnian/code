    public static class EditorRunInBackground
    {
        [RuntimeInitializeOnLoadMethod]
        private static void OnRuntimeMethodLoad()
        {
            if(Application.isEditor) Application.runInBackground = true;
        }
    }
