    class Product {
        public void Install() {
            this.OnInstalling( ... );
            ...
            this.OnInstalled( ... );
        }
        public void InstallAsync() {
            this.OnInstallingAsync( ... );
            ...
            this.OnInstalledAsync( ... );
        }
        protected virtual void OnInstalling( InstallProgressChangedEventArgs e ) {
            this.Installing.Raise(this, e);
        }
        protected virtual void OnInstallingAsync( InstallProgressChangedEventArgs e ) {
            this.Installing.RaiseAsync(this, e);
        }
        public event EventHandler<InstallProgressChangedEventArgs> Installing;
        protected virtual void OnInstalled( InstallCompletedEventArgs e ) {
            this.Installed.Raise(this, e);
        }
        protected virtual void OnInstalledAsync( InstallCompletedEventArgs e ) {
            this.Installed.RaiseAsync(this, e);
        }
        public event EventHandler<InstallCompletedEventArgs> Installed;
    }
    // ...
    public static class EventExtensions {
        public static void Raise( this EventHandler handler, object sender, EventArgs e ) {
            if (null != handler) { handler(sender, e); }
        }
    
        public static void Raise<TEventArgs>( this EventHandler<TEventArgs> handler, object sender, TEventArgs e ) where TEventArgs : EventArgs {
            if (null != handler) { handler(sender, e); }
        }
    
        public static void RaiseAsync( this EventHandler handler, object sender, EventArgs e ) {
            if (null != handler) {
                ThreadPool.QeueuUserWorkItem((_state)=>{ handler(sender, e); });
            }
        }
    
        public static void RaiseAsync<TEventArgs>( this EventHandler<TEventArgs> handler, object sender, TEventArgs e ) where TEventArgs : EventArgs {
            if (null != handler) {
                ThreadPool.QeueuUserWorkItem((_state)=>{ handler(sender, e); });
            }
        }
    }
