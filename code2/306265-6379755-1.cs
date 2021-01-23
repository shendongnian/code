        public void Serialize(object itemToSerialize)
        {
            var hasAttribute = itemToSerialize.GetType().GetCustomAttributes(typeof(SerializableAttribute), true).Any();
            // Do stuff.
        }
