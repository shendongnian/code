    using UnityEngine;
    using Microsoft.MixedReality.Toolkit.UI;
    using UnityEngine.Events;
    [RequireComponent(typeof(Interactable))]
    public class CheckBoxInteractableSwitch : MonoBehaviour
    {
        public bool startChecked = true;
        public UnityEvent OnCheck;
        public UnityEvent OnUncheck;
        private Interactable interactable;
        private int state = 1;
        void Start()
        {
            interactable = GetComponent<Interactable>();
            if (OnCheck == null)
                OnCheck = new UnityEvent();
            if (OnUncheck == null)
                OnUncheck = new UnityEvent();
            OnCheck.AddListener(Checked);
            OnUncheck.AddListener(UnChecked);
            //works with 2 dimensions only
            if (startChecked)
            {
                if (interactable.GetDimensionIndex() == 0) interactable.IncreaseDimension();
            }
            else
            {
                if (interactable.GetDimensionIndex() == 1) interactable.IncreaseDimension();
            }
        
        }
        void Update()
        {
            if (interactable == null) return;
            //state check
            if (state != interactable.GetDimensionIndex())
            {
                state = interactable.GetDimensionIndex();
                if (state == 0) OnUncheck.Invoke();
                if(state == 1) OnCheck.Invoke();
            }
        }
        private void Checked()
        {
        
        }
        private void UnChecked()
        {
       
        }
    }
