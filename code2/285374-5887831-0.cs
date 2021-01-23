    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    namespace Prototype
    {
        public partial class MdiParent : Form
        {
            private FastEyeControl m_ControlForm;
            private FastEyeLogWindow m_LogForm;
            private FastEyeConfiguration m_ConfigurationForm;
            private ROCOrderWindow m_OrderLogForm;
            private Point m_ControlFormLocation;
            private Point m_LogFormLocation;
            private Point m_ConfigurationFormLocation;
            private Point m_OrderLogFormLocation;
            public MdiParent()
            {
                InitializeComponent();
                m_ControlForm       = new FastEyeControl();
                m_LogForm           = new FastEyeLogWindow();
                m_ConfigurationForm = new FastEyeConfiguration();
                m_OrderLogForm      = new ROCOrderWindow();
                m_ControlFormLocation = new Point(0, 25);
                m_LogFormLocation = new Point(0, 405);
                m_ConfigurationFormLocation = new Point(550, 25);
                m_OrderLogFormLocation = new Point(0, 630);
            }
            private void MdiParent_Load(object sender, EventArgs e)
            {
                DockForm(m_ControlForm, m_ControlFormLocation);
                DockForm(m_LogForm, m_LogFormLocation);
                DockForm(m_ConfigurationForm, m_ConfigurationFormLocation);
                DockForm(m_OrderLogForm, m_OrderLogFormLocation);
            }
            private void exitToolStripMenuItem_Click(object sender, EventArgs e)
            {
                this.Close();
            }
            private void DockForm(Form form, Point location)
            {
                form.TopLevel = false;
                form.Location = location;
            
                if (! this.Controls.Contains(form))
                {
                    this.Controls.Add(form);
                }
                form.Visible = true;
            }
            private void UndockForm(Form form)
            {
                if (this.Controls.Contains(form))
                {
                    this.Controls.Remove(form);
                }
                form.TopLevel = true;
                form.Visible = true;
            }
            private void DockOrUndockForm(Form form, Point location)
            {
                if (this.Controls.Contains(form))
                {
                    UndockForm(form);
                }
                else
                {
                    DockForm(form, location);
                }
            }
            private void ToggleDockingOrDockForm(Form form, Point location)
            {
                if (form.Visible)
                {
                    DockOrUndockForm(form, location);
                }
                else
                {
                    DockForm(form, location);
                }
            }
            private void fastEyeControlToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ToggleDockingOrDockForm(m_ControlForm, m_ControlFormLocation);
            }
            private void fastEyeLogToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ToggleDockingOrDockForm(m_LogForm, m_LogFormLocation);
            }
            private void fastEyeConfigurationToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ToggleDockingOrDockForm(m_ConfigurationForm, m_ConfigurationFormLocation);
            }
            private void rOCOrderLogToolStripMenuItem_Click(object sender, EventArgs e)
            {
                ToggleDockingOrDockForm(m_OrderLogForm, m_OrderLogFormLocation);
            }
        }
    }
