    namespace WinformsTesting {
    
        using System;
        using System.Windows.Forms;
        using System.Drawing;
    
        public class NotifyIconManager {
    
            private NotifyIcon _ni;
    
            public void Init() {
    
                _ni = new NotifyIcon();
                _ni.MouseDoubleClick += new MouseEventHandler(_ni_MouseDoubleClick);
                _ni.Text = "This is my notify icon";
    
                Icon icon = new Icon(@"C:\temp\myicon.ico");
                _ni.Icon = icon;
                _ni.Visible = true;
    
            }
    
            void _ni_MouseDoubleClick(object sender, MouseEventArgs e) {
                MessageBox.Show("Hello");
            }
        }
    }
