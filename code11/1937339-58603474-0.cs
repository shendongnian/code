    public static class CooldownManager
    {
        private class HiddenMonobehaviour : MonoBehaviour { }
    
        private static readonly MonoBehaviour mono;
    
        static CooldownManager()
        {
            GameObject obj = new GameObject("CooldownManager");
            UnityEngine.Object.DontDestroyOnLoad(obj);
            mono = obj.AddComponent<HiddenMonobehaviour>();
        }
    
        public static Coroutine Cooldown(float cooldownDuration, Action action)
        {
            return mono.StartCoroutine(InternalCooldown(cooldownDuration, action));
        }
    
        private static IEnumerator InternalCooldown(float cooldownDuration, Action action)
        {
            yield return new WaitForSeconds(cooldownDuration);
            action.Invoke();
        }
    }
