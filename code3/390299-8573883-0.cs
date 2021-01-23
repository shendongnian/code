    using System;
    using ...
    
    namespace JobTracker.Tray {
      [Export( typeof( IJobTrackerPlugin ) )]
      public class TrayPlugin : Form, IJobTrackerPlugin {
        #region Plugin Interface
        [Import( typeof( IJobTracker ) )]
    #pragma warning disable 649
          private IJobTracker _host;
    #pragma warning restore 649
        private IJobTracker Host {
          get { return _host; }
        }
        public void Initialize() {
          trayMenu = new ContextMenu();
          trayMenu.MenuItems.Add( "Exit", OnExit );
    
          trayIcon = new NotifyIcon();
          trayIcon.Icon = new Icon( SystemIcons.Application, 32, 32 );
    
          trayIcon.ContextMenu = trayMenu;
              
          // Show the proxy form to pump messages
          Load += TrayPluginLoad;
          Thread t = new Thread(
            () => {
              ShowInTaskbar    = false;
              FormBorderStyle  = FormBorderStyle.None;
              trayIcon.Visible = true;
              ShowDialog();
            } );
          t.Start();
        }
    
        private void TrayPluginLoad( object sender, EventArgs e ) {
          // Hide the form
          Size = new Size( 0, 0 );
        }
        #endregion
    
        private NotifyIcon trayIcon;    
        private ContextMenu trayMenu;
    
        private void OnExit( object sender, EventArgs e ) {
          Application.Exit();
        }
    
        #region Implementation of IDisposable
        
        // ...
        
        private void DisposeObject( bool disposing ) {
          if( _disposed ) {
            return;
          }
          if( disposing ) {
            // Dispose managed resources.
            if( InvokeRequired ) {
              EndInvoke( BeginInvoke( new MethodInvoker( Close ) ) );
            } else {
              Close();
            }
            trayIcon.Dispose();
            trayMenu.Dispose();
          }
          // Dispose unmanaged resources.
          _disposed = true;
        }
        #endregion
      }
    }
