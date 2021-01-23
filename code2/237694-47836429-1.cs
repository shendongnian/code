        /// <summary>
        /// Set the Browsable property.
        /// NOTE: Be sure to decorate the property with [Browsable(true)]
        /// </summary>
        /// <param name="obj">An instance of the object whose property should be modified.</param>
        /// <param name="PropertyName">Name of the variable</param>
        /// <param name="bIsBrowsable">Browsable Value</param>
        private void SetBrowsableProperty<T>(T obj, string strPropertyName, bool bIsBrowsable)
        {
            SetBrowsableProperty<T>(strPropertyName, bIsBrowsable);
        }
