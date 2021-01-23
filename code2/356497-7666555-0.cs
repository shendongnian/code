        /// <summary>
        ///     The binding that will be applied to the generated element.
        /// </summary>
        /// <remarks>
        ///     This isn't a DP because if it were getting the value would evaluate the binding.
        /// </remarks>
        public virtual BindingBase Binding
        {
            get
            {
                if (!_bindingEnsured)
                {
                    if (!IsReadOnly)
                    {
                        DataGridHelper.EnsureTwoWayIfNotOneWay(_binding);
                    }
                    _bindingEnsured = true;
                }
                return _binding;
            }
            set
            {
                if (_binding != value)
                {
                    BindingBase oldBinding = _binding;
                    _binding = value;
                    CoerceValue(IsReadOnlyProperty);
                    CoerceValue(SortMemberPathProperty);
                    _bindingEnsured = false;
                    OnBindingChanged(oldBinding, _binding);
                }
            }
        }
