    using System;
    using System.Collections;
    using System.Collections.Generic;
    namespace solution2
    {
        public abstract class ObjectController
        {
            internal ObjectController master;
    
            public void Initialize(ObjectController o)
            {
                this.master = o;
            }
    
            // called before first frame
            public void Start()
            {
                Initialize(this);
                _StartPreHook(this);
            }
            // abstract funtions to be implemented in derived classes:
            public abstract void StartWrapper();
    
            // abstract function pre-hooks:
            public virtual void _StartPreHook(ObjectController master) { }
        }
        public class Selectable : ObjectController
        {
            // internal variables
            internal bool isSelected;
    
            // ui-controls
            public override void StartWrapper()
            {
                isSelected = true;
            }
    
            // pre-hooks ui-controls
            public override void _StartPreHook(ObjectController master)
            {
                this.StartPreHook(master);
            }
            public virtual void StartPreHook(ObjectController master)
            {
                isSelected = true; 
            }
        }
        public class Controllable : Selectable
        {
            public bool selectable;
            public override void StartWrapper()
            {
                selectable = true;
                isSelected = false;
            }
            public sealed override void _StartPreHook(ObjectController master)
            {
                base.StartPreHook(master);
                base.StartWrapper();
                StartPreHook(master);
            }
            public sealed override void StartPreHook(ObjectController master)
            {
                StartWrapper();
            }
        }
        public class examplechild : Controllable
        {
            public override void StartWrapper()
            {
                selectable = false; isSelected = true;
            }
        }
    }
