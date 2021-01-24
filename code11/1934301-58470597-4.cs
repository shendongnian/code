    using System.Threading;
    using UnityEngine;
    #if UNITY_EDITOR
    using UnityEditor;
    
    #endif
    namespace Threading.Internal
    {
        internal static class UnityThread
        {
    #pragma warning disable IDE0032 // Use auto property
            private static SynchronizationContext _context;
    #pragma warning restore IDE0032 // Use auto property
    
            public static SynchronizationContext Context => _context;
    
    #if UNITY_EDITOR
            [InitializeOnLoadMethod]
    #endif
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            private static void Capture()
            {
                _context = SynchronizationContext.Current;
            }
        }
    }
