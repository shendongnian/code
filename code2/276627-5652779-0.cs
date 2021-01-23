        event Action SafeEvent = () => { };
        event Action NullableEvent;        
        void Meth()
        {
            //Always ok
            SafeEvent();
            //Not safe
            NullableEvent();
            //Safe
            if (NullableEvent != null)
                NullableEvent();
        }
