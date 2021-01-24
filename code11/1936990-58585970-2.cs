        private static bool @__initialized;
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global_asax() {
            if ((global::ASP.global_asax.@__initialized == false)) {
                global::ASP.global_asax.@__initialized = true;
            }
        }
        
        protected System.Web.Profile.DefaultProfile Profile {
            get {
                return ((System.Web.Profile.DefaultProfile)(this.Context.Profile));
            }
        }
    }
