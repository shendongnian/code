    [InitializeOnLoad]
    public class RunNullChecks
    {
        public static RunNullChecks
        {
            // first of all also add a callback so it gets re-run everytime you switch a scene
            // removing it first makes sure it is only added once
            SceneManager.sceneLoaded -= Run;
            SceneManager.sceneLoaded += Run;
            Run();
        }
        private static void Run(Scene scene, LoadSceneMode mode)
        {
            Run();
        }
        public static void Run()
        {
            // here it depends a bit on your needs
            // you either can check only stuff in the Scene like
            var nullCheckers = FindObjectsOfType<INullReferenceChecker>();
            // this gets only active and enabled components!
            // or you could include all prefabs, ScriptableObjects using
            //var nullCheckers = Resources.FindObjectsOfTypeAll<INullReferenceChecker>();
            // and then let them do whatever they implemented
            foreach(var tester in nullCheckers)
            {
                tester.CheckReferences();
            }
        }
    }
