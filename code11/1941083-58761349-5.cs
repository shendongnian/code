    #if UnityEditor
    public partial class IntMonoBehaviourMock
    {
        [CustomEditor(typeof(IntMonoBehaviourMock)]
        private partial class IntMonoBehaviourMockEditor : Editor
        {
            ...
        }
    }
    #endif
