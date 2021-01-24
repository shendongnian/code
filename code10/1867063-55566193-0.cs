        // subclasses don't have to implement and override
        // this method but can. Also the base.Move(); is optional
        public virtual void Move()
        {
            Debug.Log("You might want to override this to implement a movement");
        }
        
