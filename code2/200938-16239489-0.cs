    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using System.Windows.Forms.VisualStyles;
    using System.Drawing;
    using System.ComponentModel;
    
    namespace Use.your.own
    {
        public class AdvancedRadioButton : CheckBox
        {
            public enum Level { Parent, Form };
    
            [Category("AdvancedRadioButton"),
            Description("Gets or sets the level that specifies which RadioButton controls are affected."),
            DefaultValue(Level.Parent)]
            public Level GroupNameLevel { get; set; }
    
            [Category("AdvancedRadioButton"),
            Description("Gets or sets the name that specifies which RadioButton controls are mutually exclusive.")]
            public string GroupName { get; set; }
    
            protected override void OnCheckedChanged(EventArgs e)
            {
                base.OnCheckedChanged(e);
    
                if (Checked)
                {
                    var arbControls = (dynamic)null;
                    switch (GroupNameLevel)
                    {
                        case Level.Parent:
                            if (this.Parent != null)
                                arbControls = GetAll(this.Parent, typeof(AdvancedRadioButton));
                            break;
                        case Level.Form:
                            Form form = this.FindForm();
                            if (form != null)
                                arbControls = GetAll(this.FindForm(), typeof(AdvancedRadioButton));
                            break;
                    }
                    if (arbControls != null)
                        foreach (Control control in arbControls)
                            if (control != this &&
                                (control as AdvancedRadioButton).GroupName == this.GroupName)
                                (control as AdvancedRadioButton).Checked = false;
                }
            }
    
            protected override void OnClick(EventArgs e)
            {
                if (!Checked)
                    base.OnClick(e);
            }
    
            protected override void OnPaint(PaintEventArgs pevent)
            {
                CheckBoxRenderer.DrawParentBackground(pevent.Graphics, pevent.ClipRectangle, this);
                
    			RadioButtonState radioButtonState;
                if (Checked)
                {
                    radioButtonState = RadioButtonState.CheckedNormal;
                    if (Focused)
                        radioButtonState = RadioButtonState.CheckedHot;
                    if (!Enabled)
                        radioButtonState = RadioButtonState.CheckedDisabled;
                }
                else
                {
                    radioButtonState = RadioButtonState.UncheckedNormal;
                    if (Focused)
                        radioButtonState = RadioButtonState.UncheckedHot;
                    if (!Enabled)
                        radioButtonState = RadioButtonState.UncheckedDisabled;
                }
    
                Size glyphSize = RadioButtonRenderer.GetGlyphSize(pevent.Graphics, radioButtonState);
                Rectangle rect = pevent.ClipRectangle;
                rect.Width -= glyphSize.Width;
                rect.Location = new Point(rect.Left + glyphSize.Width, rect.Top);
    
                RadioButtonRenderer.DrawRadioButton(pevent.Graphics, new System.Drawing.Point(0, rect.Height / 2 - glyphSize.Height / 2), rect, this.Text, this.Font, this.Focused, radioButtonState);
            }
    
            private IEnumerable<Control> GetAll(Control control, Type type)
            {
                var controls = control.Controls.Cast<Control>();
    
                return controls.SelectMany(ctrl => GetAll(ctrl, type))
                                          .Concat(controls)
                                          .Where(c => c.GetType() == type);
            }
        }
    }
