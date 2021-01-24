        public void SetActive(bool active)
        {
            foreach(var listener in ThingsToActivate)
            {
                listener.Active = active;
            }
        }
