    private int _abilityModifier;
    public int AbilityModifier
    {
        get { return Convert.ToInt32(AbilityModifierTextBox.Text); }
        private set {
            if (value != _abilityModifier) {
                _abilityModifier = value;
                AbilityModifierTextBox.Text = value >= 0
                    ? String.Format("+{0}", value)
                    : value.ToString();
                OnPropertyChanged(nameof(AbilityModifier));
            }
        }
    }
