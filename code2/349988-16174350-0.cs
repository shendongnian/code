    public class ResourcesProxy : Properties.Resources
    {
        /// <summary>
        /// resolves the problem of internal constructor in resources.designer.cs
        /// in conjunction with xaml usage
        /// </summary>
        public ResourcesProxy() : base()
        {
        }
    }
