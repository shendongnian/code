        public event Action<BaseItemSlot> RightButtonClicked;
        void OnRightButtonClicked()
        {
            if (RightButtonClicked == null) return;
            for (int i = 0; i < ItemSlots.Count; i++)
            {
                RightButtonClicked(ItemSlots[i]);
            }
        }
