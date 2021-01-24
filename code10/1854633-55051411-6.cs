        void OnEnable()
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                ItemSlots[i].RightButtonClicked += OnRightButtonClicked;
            }
        }
        void OnDisable()
        {
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                ItemSlots[i].RightButtonClicked -= OnRightButtonClicked;
            }
        }
