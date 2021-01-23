    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    namespace ValidationControls
    {
      [ProvideProperty("ErrorMessage", typeof (TextBoxBase))]
      [ProvideProperty("RegEx", typeof (TextBoxBase))]
      public partial class ValidationComponent : Component, IExtenderProvider
      {
        private readonly Dictionary<Control, string> _errorMessages =
          new Dictionary<Control, string>();
    
        private readonly Dictionary<Control, string> _regExDictionary =
          new Dictionary<Control, string>();
    
        private TextBoxBase _activeControl;
        private ErrorProvider _errorProvider;
    
        public ValidationComponent()
        {
          InitializeComponent();
        }
    
        public ValidationComponent(IContainer container)
        {
          container.Add(this);
    
          InitializeComponent();
        }
    
        public ErrorProvider ErrorProvider
        {
          get { return _errorProvider; }
          set { _errorProvider = value; }
        }
    
        #region IExtenderProvider Members
    
        public bool CanExtend(object extendee)
        {
          return extendee is TextBoxBase;
        }
    
        #endregion
    
        [DefaultValue("")]
        [Category("Validation")]
        public string GetRegEx(TextBoxBase control)
        {
          string value;
          return _regExDictionary.TryGetValue(control, out value) ? value : string.Empty;
        }
    
        [Category("Validation")]
        public void SetRegEx(TextBoxBase control, string value)
        {
          if (string.IsNullOrWhiteSpace(value))
          {
            _regExDictionary.Remove(control);
    
            control.Validating -= OnControlValidating;
            control.Validated -= OnControlValidated;
          }
          else
          {
            _regExDictionary[control] = value;
    
            control.Validating += OnControlValidating;
            control.Validated += OnControlValidated;
          }
        }
    
        [Category("Validation")]
        public string GetErrorMessage(TextBoxBase control)
        {
          string value;
          return _errorMessages.TryGetValue(control, out value) ? value : string.Empty;
        }
    
        [Category("Validation")]
        public void SetErrorMessage(TextBoxBase control, string value)
        {
          if (string.IsNullOrWhiteSpace(value))
          {
            _errorMessages.Remove(control);
          }
          else
          {
            _errorMessages[control] = value;
          }
        }
    
        private void OnControlValidating(object sender, CancelEventArgs e)
        {
          _activeControl = (TextBoxBase) sender;
          var regExPattern = GetRegEx(_activeControl);
    
          if (Regex.IsMatch(_activeControl.Text, regExPattern, RegexOptions.Singleline))
            return;
          e.Cancel = true;
    
          var errorMsg = GetErrorMessage(_activeControl);
    
          if (_errorProvider != null)
            _errorProvider.SetError(_activeControl, errorMsg);
        }
    
        private void OnControlValidated(object sender, EventArgs e)
        {
          if (sender != _activeControl)
            return;
          if (_errorProvider != null)
            _errorProvider.SetError(_activeControl, "");
          _activeControl = null;
        }
      }
    }
