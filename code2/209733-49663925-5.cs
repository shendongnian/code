    internal class Resources
    {
        private static CachedResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static CachedResourceManager ResourceManager 
        {
            get {
                   if (object.ReferenceEquals(resourceMan, null))
                   {
                      CachedResourceManager temp = new CachedResourceManager("Project.Properties.Resources", typeof(Resources).Assembly);
                      resourceMan = temp;
                   }
                   return resourceMan;
                }
        }
        // Image/object properties for your resources
    } // End of resources class
