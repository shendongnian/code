        public static Component GetComponentOfType<T>(GameObject gameObject)
        {
            return gameObject.GetComponents<Component>().Where(c => c is T).FirstOrDefault();
        }
Usage:
        private IMovement movementComponent
        {
            get //When we try to retrieve this value.
            {
                if (storedMovementComponent != null) //Check if this value has already been set.
                {
                    return storedMovementComponent; //If the component does exist, return it.
                }
                else
                {
                    return (IMovement)Utilities.GetComponentOfType<IMovement>(gameObject);
                }
            }
        }
