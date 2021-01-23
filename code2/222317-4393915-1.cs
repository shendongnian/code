    using System;
    using System.Collections;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Caching;
    using System.Web.Hosting;
    public class TildeModifyingVPP : VirtualPathProvider {
        // Change this to what you want ~ to map to
        private const string PseudoRoot = "~/PseudoAppRoot/";
        public static void AppInitialize() {
            HostingEnvironment.RegisterVirtualPathProvider(new TildeModifyingVPP());
        }
        private string ResolvePath(string virtualPath) {
            // Make it app relative, i.e. ~/...
            virtualPath = VirtualPathUtility.ToAppRelative(virtualPath);
            // Change the ~/ to our pseudo root
            return PseudoRoot + virtualPath.Substring(2);
        }
        public override bool FileExists(string virtualPath) {
            return base.FileExists(ResolvePath(virtualPath));
        }
        public override VirtualFile GetFile(string virtualPath) {
            return new DelegatingVirtualFile(virtualPath, base.GetFile(ResolvePath(virtualPath)));
        }
        public override bool DirectoryExists(string virtualDir) {
            return base.DirectoryExists(ResolvePath(virtualDir));
        }
        public override VirtualDirectory GetDirectory(string virtualDir) {
            return new DelegatingVirtualDirectory(virtualDir, base.GetDirectory(ResolvePath(virtualDir)));
        }
        public override CacheDependency GetCacheDependency(string virtualPath, IEnumerable virtualPathDependencies, DateTime utcStart) {
            virtualPathDependencies = virtualPathDependencies.Cast<string>().Select(vpath => ResolvePath(vpath));
            return base.GetCacheDependency(virtualPath, virtualPathDependencies, utcStart);
        }
    }
    class DelegatingVirtualFile : VirtualFile {
        private VirtualFile _underlyingFile;
        public DelegatingVirtualFile(string virtualPath, VirtualFile underlyingFile): base(virtualPath) {
            _underlyingFile = underlyingFile;
        }
        public override Stream Open() {
            return _underlyingFile.Open();
        }
    }
    class DelegatingVirtualDirectory : VirtualDirectory {
        private VirtualDirectory _underlyingDir;
        public DelegatingVirtualDirectory(string virtualPath, VirtualDirectory underlyingDir)
            : base(virtualPath) {
            _underlyingDir = underlyingDir;
        }
        public override IEnumerable Children { get { return _underlyingDir.Children; } }
        public override IEnumerable Directories { get { return _underlyingDir.Directories; } }
        public override IEnumerable Files { get { return _underlyingDir.Files; } }
    }
