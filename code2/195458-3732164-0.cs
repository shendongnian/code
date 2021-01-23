    public class CustomRadioButton : RadioButton
    {
        private bool _suppressCheckedEvent;
    
        public void SetChecked(bool value, bool suppressCheckedEvent)
        {
            if (!suppressCheckedEvent)
                Checked = value;
            else
            {
                SetSupressModeForGroup(true);
                Checked = value;
                SetSupressModeForGroup(false);
            }
        }
    
        private void SetSupressModeForGroup(bool suppressCheckedEvent)
        {
            foreach (var crb in Parent.Controls.OfType<CustomRadioButton>())
                crb._suppressCheckedEvent = suppressCheckedEvent;
        }
    
        protected override void OnCheckedChanged(EventArgs e)
        {
            if (!_suppressCheckedEvent)
                base.OnCheckedChanged(e);
        }   
    }
