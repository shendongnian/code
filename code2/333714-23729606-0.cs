    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace MyNameSpace
    {
        public partial class DateTimePicker2 : DateTimePicker
        {
            private bool _checked;
    
            public new bool Checked
            {
                get
                {
                    return base.Checked;
                }
                set
                {
                    if (value != base.Checked)
                    {
                        base.Checked = value;
                        _checked = base.Checked;
                        OnCheckedChanged(new CheckedChangedEventArgs { OldCheckedValue = !value, NewCheckedValue = value });
                    }
                }
            }
    
            public event CheckedChangedEventHandler CheckedChanged;
    
            public DateTimePicker2()
            {
                InitializeComponent();
                _checked = Checked;
            }
    
    
            protected virtual void OnCheckedChanged(CheckedChangedEventArgs e)
            {
                if (CheckedChanged != null) CheckedChanged(this, e);
            }
    
            private void DateTimePicker2_ValueChanged(object sender, EventArgs e)
            {
                if (Checked != _checked)
                {
                    _checked = Checked;
                    CheckedChangedEventArgs cce = new CheckedChangedEventArgs { OldCheckedValue = !_checked, NewCheckedValue = _checked };
                    OnCheckedChanged(cce);
                }
            } 
        }
    
        public delegate void CheckedChangedEventHandler(object sender, CheckedChangedEventArgs e);
    
        public class CheckedChangedEventArgs : EventArgs
        {
            public bool OldCheckedValue { get; set; }
            public bool NewCheckedValue { get; set; }
        }
    
    }
