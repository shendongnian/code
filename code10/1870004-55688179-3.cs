    [System.Serializable]
    public class UnderWaterParameters {
        [Header("The following parameters apply for underwater only!")]
        [Space(5)]
        public float fogDensity = 0.1f;
        public Color fogColor;
    #if UNITY_POST_PROCESSING_STACK_V1 && AQUAS_PRESENT
        [Space(5)]
        [Header("Post Processing Profiles (Must NOT be empty!)")]
        [Space(5)]
    #elif UNITY_POST_PROCESSING_STACK_V2 && AQUAS_PRESENT
        [Space(5)]
        [Header("Post Processing Profiles (Must NOT be empty!)")]
        [Space(5)] }
    #endif
        public PostProcessingProfile underwaterProfile;
        public PostProcessingProfile defaultProfile;
    }
    
