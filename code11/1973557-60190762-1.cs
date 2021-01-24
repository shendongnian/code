    using UnityEngine;
    public class LightPressable : Pressable
    {
        Light light = null;
        protected override void Start()
        {
            base.Start();
            light = GetComponentInChildren<Light>();
            UpdateBasedOnActive();
        }
        public override void Press()
        {
            base.Press();
            UpdateBasedOnActive();
        }
        void UpdateBasedOnActive()
        {
            light.enabled = active;
        }
    }
